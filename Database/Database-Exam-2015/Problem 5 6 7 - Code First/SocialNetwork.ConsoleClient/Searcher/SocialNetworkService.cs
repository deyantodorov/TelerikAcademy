namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using Newtonsoft.Json;
    using SocialNetwork.Data;

    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialNetworkDbContext data;

        public SocialNetworkService()
        {
            this.data = new SocialNetworkDbContext();
        }

        /// <summary>
        /// Get Username, FirstName, LastName, and number of images for
        /// all users which registration year is greater than or equal to the provided year
        /// </summary>
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var result = new List<UsersAfterCertainDate>();

            if (year < 0)
            {
                return result;
            }

            result = this.data
                .Users
                .Where(user => user.RegistrationDate.Year >= year)
                .Select(user => new UsersAfterCertainDate()
                {
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NumberOfImages = user.Images.Count,
                    RegistrationDate = user.RegistrationDate
                })
                .ToList();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        /// <summary>
        /// Get all posts in which the user with the provided username is tagged.
        /// Select PostedOn, Content and all usernames of the tagged users in the post.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable GetPostsByUser(string username)
        {
            var result = new List<UsersTagged>();

            if (string.IsNullOrWhiteSpace(username))
            {
                return result;
            }

            result = this.data.Posts
                .Where(p => p.Users.Any(u => u.UserName == username))
                .Select(p => new UsersTagged()
                {
                    Content = p.Content,
                    PostedOn = p.PostingDate,
                    Username = username,
                    UsernamesOfTaggedUsers = p.Users.Count,
                })
                .ToList();


            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        /// <summary>
        /// Get all approved friendships, ordered ascending by the friendship date and
        /// paged by the provided numbers. Select FirstUserUsername, FirstUserImage,
        /// SecondUserUsername, SecondUserImage. Images are just the URLs of the first image for each user.
        /// </summary>
        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var result = new List<FriendshipJson>();

            result = this.data.Friendships
                .Where(x => x.Approved)
                .OrderBy(x => x.ApproveDate)
                .Skip(page - 1)
                .Take(pageSize)
                .Select(x => new FriendshipJson()
                {
                    FirstUserUsername = x.FirstUser.UserName,
                    FirstUserImage = x.FirstUser.Images.FirstOrDefault(i => i.UserId == x.FirstUserId).ImageUrl,
                    SecondUserUsername = x.SecondUser.UserName,
                    SecondUserImage = x.SecondUser.Images.FirstOrDefault(i => i.UserId == x.SecondUserId).ImageUrl,
                })
                .ToList();


            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        /// <summary>
        /// Get all usernames of all the unique users with which the provided user by username
        /// has at least one chat message, ordered alphabetically.
        /// </summary>
        public IEnumerable GetChatUsers(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username", "Can't be empty or null");
            }

            var result = this.data.Messages
                .Where(m => m.Friendship.FirstUser.UserName == username)
                .Select(m => m.Friendship.SecondUser.UserName)
                .Union(
                    this.data.Messages
                        .Where(m => m.Friendship.SecondUser.UserName == username)
                        .Select(m => m.Friendship.FirstUser.UserName)
                )
                .Where(u => u != username)
                .Distinct()
                .OrderBy(u => u)
                .ToList();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}