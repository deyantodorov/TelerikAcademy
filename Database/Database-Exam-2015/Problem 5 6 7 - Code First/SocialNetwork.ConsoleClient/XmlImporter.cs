namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public class XmlImporter
    {
        private const string FriendshipPath = @"XmlFiles/Friendships.xml";
        private const string PostsPath = @"XmlFiles/Posts.xml";
        private SocialNetworkDbContext data;

        public XmlImporter()
        {
            this.data = new SocialNetworkDbContext();
        }

        public void Execute()
        {
            this.FriendshipImport();
            Console.WriteLine("Friendship imported");

            this.PostsImport();
            Console.WriteLine("Posts imported");
        }

        private void FriendshipImport()
        {
            var document = new XmlDocument();
            document.Load(FriendshipPath);

            var root = document.DocumentElement;

            if (root != null)
            {
                var recordIndex = 0;
                foreach (XmlNode node in root.ChildNodes)
                {
                    // relationship true/false
                    bool relationType = bool.Parse(node.Attributes["Approved"].InnerText);
                    DateTime friendsSince = DateTime.Now;

                    if (relationType)
                    {
                        friendsSince = DateTime.Parse(node.FirstChild.InnerText);
                    }


                    var friendship = new Friendship();

                    // only for approved friendships
                    if (relationType)
                    {
                        friendship.Approved = true;
                        friendship.ApproveDate = friendsSince;
                    }
                    else
                    {
                        friendship.Approved = false;
                    }

                    // I know it's bad practise, but no time for refactoring
                    #region FIRST USER
                    int firstId;

                    var firstUser = this.GetUserFromNode(
                        node.SelectSingleNode("FirstUser/Username"),
                        node.SelectSingleNode("FirstUser/FirstName"),
                        node.SelectSingleNode("FirstUser/LastName"),
                        node.SelectSingleNode("FirstUser/RegisteredOn"));

                    var firstImages = this.GetImagesFromNode(node.SelectNodes("FirstUser/Images/Image"));

                    if (this.data.Users.Any(x => x.UserName == firstUser.UserName))
                    {
                        // update user info and images
                        var user = this.data
                            .Users
                            .First(x => x.UserName == firstUser.UserName);

                        user.FirstName = firstUser.FirstName;
                        user.LastName = firstUser.LastName;
                        user.RegistrationDate = firstUser.RegistrationDate;

                        if (firstImages.Count > 0)
                        {
                            foreach (var firstImage in firstImages)
                            {
                                user.Images.Add(firstImage);
                            }
                        }

                        this.data.Users.AddOrUpdate(user);
                        this.data.SaveChanges();
                        this.data = new SocialNetworkDbContext();

                        firstId = user.Id;
                    }
                    else
                    {
                        // add user and get id

                        if (firstImages.Count > 0)
                        {
                            foreach (var firstImage in firstImages)
                            {
                                firstUser.Images.Add(firstImage);
                            }
                        }

                        this.data.Users.AddOrUpdate(firstUser);
                        this.data.SaveChanges();

                        firstId = this.data.Users.First(x => x.UserName == firstUser.UserName).Id;

                        this.data = new SocialNetworkDbContext();
                    }
                    #endregion

                    // I know it's bad practise, but no time for refactoring
                    #region SECOND USER
                    int secondId;

                    var secondUser = this.GetUserFromNode(
                        node.SelectSingleNode("SecondUser/Username"),
                        node.SelectSingleNode("SecondUser/FirstName"),
                        node.SelectSingleNode("SecondUser/LastName"),
                        node.SelectSingleNode("SecondUser/RegisteredOn"));

                    var secondImages = this.GetImagesFromNode(node.SelectNodes("SecondUser/Images/Image"));

                    if (this.data.Users.Any(x => x.UserName == secondUser.UserName))
                    {
                        // update user info and images
                        var user = this.data
                            .Users
                            .First(x => x.UserName == secondUser.UserName);

                        user.FirstName = secondUser.FirstName;
                        user.LastName = secondUser.LastName;
                        user.RegistrationDate = secondUser.RegistrationDate;

                        if (secondImages.Count > 0)
                        {
                            foreach (var secondImage in secondImages)
                            {
                                user.Images.Add(secondImage);
                            }
                        }

                        this.data.Users.AddOrUpdate(user);
                        this.data.SaveChanges();
                        this.data = new SocialNetworkDbContext();

                        secondId = user.Id;
                    }
                    else
                    {
                        // add user and get id

                        if (secondImages.Count > 0)
                        {
                            foreach (var secondImage in secondImages)
                            {
                                secondUser.Images.Add(secondImage);
                            }
                        }

                        this.data.Users.AddOrUpdate(secondUser);
                        this.data.SaveChanges();

                        secondId = this.data.Users.First(x => x.UserName == secondUser.UserName).Id;

                        this.data = new SocialNetworkDbContext();
                    }
                    #endregion

                    // MESSAGES
                    var messages = this.GetMessages(node.SelectNodes("Messages/Message"));

                    friendship.FirstUserId = firstId;
                    friendship.SecondUserId = secondId;

                    if (messages.Count > 0)
                    {
                        friendship.Messages = messages;
                    }

                    this.data.Friendships.Add(friendship);

                    if (recordIndex%10==0)
                    {
                        Console.Write(".");
                    }

                    if (recordIndex % 50 == 0)
                    {
                        this.data.SaveChanges();
                        this.data.Dispose();
                        this.data = new SocialNetworkDbContext();
                    }
                    
                    recordIndex++;
                }

                this.data.SaveChanges();
            }
        }

        private void PostsImport()
        {
            var document = new XmlDocument();
            document.Load(PostsPath);

            var root = document.DocumentElement;

            if (root != null)
            {
                var recordsIndex = 0;

                foreach (XmlNode node in root.ChildNodes)
                {
                    var post = new Post
                    {
                        Content = node.SelectSingleNode("Content").InnerText,
                        PostingDate = DateTime.Parse(node.SelectSingleNode("PostedOn").InnerText)
                    };

                    var users = node.SelectSingleNode("Users").InnerText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var postUsers = users.Select(user => this.data.Users.First(x => x.UserName == user)).ToList();

                    if (postUsers.Count > 0)
                    {
                        foreach (var usr in postUsers)
                        {
                            post.Users.Add(usr);
                        }
                    }

                    Console.Write(".");

                    this.data.Posts.Add(post);

                    if (recordsIndex % 100 == 0)
                    {
                        this.data.SaveChanges();
                        this.data.Dispose();
                        this.data = new SocialNetworkDbContext();
                    }

                    recordsIndex++;
                }

                this.data.SaveChanges();
            }
        }

        private List<Message> GetMessages(XmlNodeList messages)
        {
            var result = new List<Message>();

            if (messages.Count <= 0)
            {
                return result;
            }

            foreach (XmlNode message in messages)
            {
                // todo get author id

                var author = message.SelectSingleNode("Author").InnerText;
                var content = message.SelectSingleNode("Content").InnerText;
                var sentOn = message.SelectSingleNode("SentOn").InnerText;
                var seenOn = message.SelectSingleNode("SeenOn") == null ? null : message.SelectSingleNode("SeenOn").InnerText;

                var msg = new Message();
                msg.Content = content;
                msg.SendTime = DateTime.Parse(sentOn);
                msg.AuthorId = this.data.Users.First(x => x.UserName == author).Id;

                if (!string.IsNullOrWhiteSpace(seenOn))
                {
                    msg.SeeingDate = DateTime.Parse(seenOn);
                }

                result.Add(msg);
            }

            return result;
        }

        private List<Image> GetImagesFromNode(XmlNodeList images)
        {
            var result = new List<Image>();

            if (images.Count <= 0)
            {
                return result;
            }

            foreach (XmlNode image in images)
            {
                var url = image.SelectSingleNode("ImageUrl").InnerText;
                var ext = image.SelectSingleNode("FileExtension").InnerText;

                var img = new Image()
                {
                    ImageUrl = url,
                    FileExtension = ext,
                };

                result.Add(img);
            }

            return result;
        }

        private User GetUserFromNode(XmlNode username, XmlNode firstName, XmlNode lastName, XmlNode registeredOn)
        {
            var user = new User()
            {
                UserName = username.InnerText,
                FirstName = firstName == null ? null : firstName.InnerText,
                LastName = lastName == null ? null : lastName.InnerText,
                RegistrationDate = DateTime.Parse(registeredOn.InnerText)
            };

            return user;
        }

        //private void FriendshipImport()
        //{
        //    var document = GetRootNodeXmlDocument(FriendshipPath);

        //    string XPathQuery = "/Friendships/Friendship";

        //    var friendships = document.SelectNodes(XPathQuery);

        //    foreach (XmlElement friendship in friendships)
        //    {
        //        XPathQuery = "FriendsSince";
        //        var friendshipSince = friendship.SelectNodes(XPathQuery);
        //        DateTime friendshipsSinceDate;

        //        if (friendshipSince != null && friendshipSince.Count == 1)
        //        {
        //            // aproved friendship
        //            friendshipsSinceDate = DateTime.Parse(friendshipSince[0].InnerText);

        //            // first user - test exist
        //            XPathQuery = "FirstUser/Username";
        //            var firstUsername = friendship.SelectSingleNode(XPathQuery).InnerText;

        //            XPathQuery = "FirstUser/FirstName";
        //            var firstFirstName = friendship.SelectSingleNode(XPathQuery).InnerText ?? "";

        //            XPathQuery = "FirstUser/LastName";
        //            var firstLastName = friendship.SelectSingleNode(XPathQuery).InnerText ?? "";

        //            XPathQuery = "FirstUser/RegisteredOn";
        //            var firstRegisteredOn = DateTime.Parse(friendship.SelectSingleNode(XPathQuery).InnerText);

        //            User firstFriendshipUser;

        //            var firstUser = new User()
        //            {
        //                UserName = firstUsername,
        //                FirstName = firstFirstName,
        //                LastName = firstLastName,
        //                RegistrationDate = firstRegisteredOn
        //            };

        //            XPathQuery = "FirstUser/Images/Image";
        //            var images = friendship.SelectNodes(XPathQuery);
        //            var dbImages = new List<Image>();

        //            if (images != null && images.Count > 0)
        //            {
        //                for (var i = 0; i < images.Count; i++)
        //                {
        //                    XPathQuery = "FirstUser/Images/Image";
        //                    var currentImage = friendship.SelectNodes(XPathQuery);
        //                    var singleImg = currentImage[i].ChildNodes;

        //                    var url = singleImg[0].InnerText;
        //                    var ext = singleImg[1].InnerText;

        //                    var img = new Image()
        //                    {
        //                        ImageUrl = url,
        //                        FileExtension = ext,
        //                    };

        //                    dbImages.Add(img);
        //                }
        //            }

        //            if (dbImages.Count > 0)
        //            {
        //                firstUser.Images = dbImages;
        //            }

        //            this.data.Users.AddOrUpdate(firstUser);
        //            this.data.SaveChanges();

        //            firstFriendshipUser = this.data.Users.First(x => x.UserName == firstUsername);

        //            // first user - test exist
        //            XPathQuery = "SecondUser/Username";
        //            var secondUsername = friendship.SelectSingleNode(XPathQuery).InnerText;

        //            XPathQuery = "SecondUser/FirstName";
        //            var secondFirstName = friendship.SelectSingleNode(XPathQuery).InnerText ?? "";

        //            XPathQuery = "SecondUser/LastName";
        //            var secondLastName = friendship.SelectSingleNode(XPathQuery).InnerText ?? "";

        //            XPathQuery = "SecondUser/RegisteredOn";
        //            var secondRegisteredOn = DateTime.Parse(friendship.SelectSingleNode(XPathQuery).InnerText);

        //            User secondFriendshipUser;

        //            var secondUser = new User()
        //            {
        //                UserName = secondUsername,
        //                FirstName = secondFirstName,
        //                LastName = secondLastName,
        //                RegistrationDate = secondRegisteredOn
        //            };

        //            XPathQuery = "SecondUser/Images/Image";
        //            images = friendship.SelectNodes(XPathQuery);
        //            dbImages = new List<Image>();

        //            if (images != null && images.Count > 0)
        //            {
        //                for (var i = 0; i < images.Count; i++)
        //                {
        //                    XPathQuery = "SecondUser/Images/Image";
        //                    var currentImage = friendship.SelectNodes(XPathQuery);
        //                    var singleImg = currentImage[i].ChildNodes;

        //                    var url = singleImg[0].InnerText;
        //                    var ext = singleImg[1].InnerText;

        //                    var img = new Image()
        //                    {
        //                        ImageUrl = url,
        //                        FileExtension = ext,
        //                    };

        //                    dbImages.Add(img);
        //                }
        //            }

        //            if (dbImages.Count > 0)
        //            {
        //                secondUser.Images = dbImages;
        //            }

        //            this.data.Users.AddOrUpdate(secondUser);
        //            this.data.SaveChanges();

        //            secondFriendshipUser = this.data.Users.First(x => x.UserName == firstUsername);

        //            var freindship = new Friendship()
        //            {
        //                Approved = true,
        //                ApproveDate = friendshipsSinceDate,
        //                FirstUser = firstFriendshipUser,
        //                SecondUser = secondFriendshipUser
        //            };

        //            this.data.Friendships.Add(freindship);
        //            this.data.Dispose();
        //            this.data = new SocialNetworkDbContext();
        //        }
        //        else
        //        {
        //            // not approved friendship
        //        }
        //    }
        //}

        //private void PostsImport()
        //{
        //    var document = GetRootNodeXmlDocument(PostsPath);

        //    string XPathQuery = "/Posts/Post";

        //    var messages = document.SelectNodes(XPathQuery);

        //    var index = 0;
        //    foreach (XmlElement message in messages)
        //    {
        //        var content = message.SelectSingleNode("Content").InnerText ?? "";
        //        var postDate = message.SelectSingleNode("PostedOn").InnerText;
        //        var users = message.SelectSingleNode("Users").InnerText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        //        var post = new Post()
        //        {
        //            Content = content,
        //            PostingDate = DateTime.Parse(postDate)
        //        };

        //        List<User> userToInsert = new List<User>();

        //        User user;
        //        for (int i = 0; i < users.Count(); i++)
        //        {
        //            var currentUser = users[i];

        //            if (this.data.Users.Any(x => x.UserName == currentUser))
        //            {
        //                user = this.data.Users.First(x => x.UserName == currentUser);
        //                userToInsert.Add(user);
        //            }
        //            else
        //            {
        //                user = new User
        //                {
        //                    UserName = users[i]
        //                };

        //                userToInsert.Add(user);
        //            }
        //        }
        //        this.data.Posts.Add(post);

        //        this.data.SaveChanges();
        //    }


        //}
    }
}
