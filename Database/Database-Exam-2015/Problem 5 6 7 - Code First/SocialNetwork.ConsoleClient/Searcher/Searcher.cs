namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections.Generic;
    using System.IO;

    public class DataSearcher
    {
        public static void Search(ISocialNetworkService searcher)
        {
            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            var jsons = new List<string>
            {
                users.ToString(),
                postsByUsers.ToString(),
                friendships.ToString(),
                chatUsers.ToString()
            };


            for (int i = 1; i <= jsons.Count; i++)
            {
                using (var writer = new StreamWriter(string.Format("../../JsonFiles/Result{0}.json", i)))
                {
                    writer.WriteLine(jsons[i - 1]);
                }
            }

            //SaveJsonToFile("Result1.json", users.ToString());
        }

        //private static void SaveJsonToFile(string saveTo, string json)
        //{
        //    using (StreamWriter writer = new StreamWriter(saveTo))
        //    {
        //        writer.Write(json.ToCharArray());
        //    }
        //}
    }
}
