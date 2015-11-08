using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace T02.TradeCompany
{
    public class Store
    {
        private readonly OrderedMultiDictionary<int, Article> articles;

        public Store()
        {
            this.articles = new OrderedMultiDictionary<int, Article>(true);
        }

        public void Add(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article", "Article can't be null");
            }

            this.articles.Add(article.GetHashCode(), article);
        }

        public void Remove(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article", "Article can't be null");
            }

            this.articles.Remove(article.GetHashCode(), article);
        }

        public List<KeyValuePair<int, ICollection<Article>>> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var result = this.articles.FindAll(x => x.Value.All(y => y.Price >= minPrice && y.Price <= maxPrice)).ToList();

            return result;
        }
    }
}
