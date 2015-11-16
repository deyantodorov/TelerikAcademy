using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;

namespace DropboxImageShare
{
    public class Program
    {
        private const string DropboxAppKey = "wvk217rimxwcj4k";
        private const string DropboxAppSecret = "hwalyblsgz66jsw";
        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";
        private const string ImagesFolder = @"..\..\images";

        private static void Main()
        {
            var dropboxServiceProvider = new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }

            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Create new folder
            string newFolderName = "Images_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);


            foreach (var file in Directory.GetFiles(ImagesFolder))
            {

                var resource = new FileResource(file);
                var fileName = resource.File.Name;

                // Upload Image
                var upload = dropbox.UploadFileAsync(resource, fileName, true, null, CancellationToken.None).Result;

                // Print path
                Console.WriteLine("Uploaded a file: {0}", upload.Path);

                // Share Image
                var sharedUrl = dropbox.GetShareableLinkAsync(upload.Path).Result;
                Process.Start(sharedUrl.Url);
            }
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, parameters);

            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);

            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken = dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}