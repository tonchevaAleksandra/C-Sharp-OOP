using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;


namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> productsByIndex;
        private readonly HashSet<string> productLabels;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly SortedDictionary<decimal, List<IProduct>> productSortedByPrice;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;
        public ProductStock()
        {
            this.productsByIndex = new List<IProduct>();
            this.productLabels = new HashSet<string>();
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.productSortedByPrice = new SortedDictionary<decimal, List<IProduct>>(
                Comparer<decimal>.Create((first, second) => second.CompareTo(first)));

            this.productsByQuantity = new Dictionary<int, List<IProduct>>();

        }
        public int Count => this.productsByIndex.Count;

        public bool Contains(IProduct product)
        {
            if (product == null)
                throw new ArgumentException("Product cannot be null!");

            return this.productLabels.Contains(product.Label);
        }
        public void Add(IProduct product)
        {
            if (product == null)
                throw new ArgumentException("Product cannot be null.");

            if (this.productLabels.Contains(product.Label))
                throw new ArgumentException($"A product with '{product.Label}' label already exist!");

            InitializeCollections(product);

            this.productLabels.Add(product.Label);
            this.productsByIndex.Add(product);
            this.productsByLabel[product.Label] = product;
            this.productsByQuantity[product.Quantity].Add(product);
            this.productSortedByPrice[product.Price].Add(product);
        }


        public IProduct Find(int index)
        {
            if (index > this.productsByIndex.Count - 1 || index < 0)
                throw new IndexOutOfRangeException("Product index does not exist.");

            return this.productsByIndex[index];
        }


        public IProduct FindByLabel(string label)
        {
            if (String.IsNullOrEmpty(label) || String.IsNullOrWhiteSpace(label))
                throw new ArgumentException("The label cannot be null, empty or whitespace.");

            if (!this.productsByLabel.ContainsKey(label))
                throw new ArgumentException("Product with such label does not exist.");

            return this.productsByLabel[label];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var priceDecimal = (decimal)price;
            if (!this.productSortedByPrice.ContainsKey(priceDecimal))
                return Enumerable.Empty<IProduct>();

            return this.productSortedByPrice[(decimal)price];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (!this.productsByQuantity.ContainsKey(quantity))
                return Enumerable.Empty<Product>();

            return this.productsByQuantity[quantity];

        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {

            var result = new List<IProduct>();
            foreach (var (price, products) in this.productSortedByPrice)
            {
                if ((double)price >= lo && (double)price <= hi)
                {
                    result.AddRange(products);
                }
                if ((double)price < lo)
                    break;
            }
            if (!result.Any() || !this.productSortedByPrice.Any())
                return Enumerable.Empty<IProduct>();

            return result;
        }
        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productSortedByPrice.Any())
                throw new InvalidOperationException("The productStock is empty.");

            var mostExpensiveProducts = this.productSortedByPrice.First().Value;
            return mostExpensiveProducts.First();
        }

        public IEnumerator<IProduct> GetEnumerator() => this.productsByIndex.GetEnumerator();
        public IProduct this[int index]
        {
            get => this.Find(index);
            set
            {
                if(value==null)
                  throw new IndexOutOfRangeException("Index is out of range.");

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollections(value);

                this.productsByIndex[index] = value;
            }
        }

        public bool Remove(IProduct product)
        {

            if (product == null)
                throw new ArgumentNullException("The product cannot be null!");

            if (!this.productLabels.Any())
                throw new InvalidOperationException("There is no products in stock.");

            var label = product.Label;

            if (!this.productLabels.Contains(label))
                return false;

            this.RemoveProductFromCollections(product);
         
            this.productsByIndex.RemoveAll(pr=>pr.Label==label);
          
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void InitializeCollections(IProduct product)
        {
            if (!this.productsByQuantity.ContainsKey(product.Quantity))
                this.productsByQuantity[product.Quantity] = new List<IProduct>();

            if (!this.productSortedByPrice.ContainsKey(product.Price))
                this.productSortedByPrice[product.Price] = new List<IProduct>();

        }

        private void RemoveProductFromCollections(IProduct product)
        {
            var label = product.Label;
            this.productLabels.Remove(label);
           
            this.productsByLabel.Remove(label);

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == label);

            var allWithProductPrice = this.productSortedByPrice[product.Price];
            allWithProductPrice.RemoveAll(pr => pr.Label == label);

        }
    }

}
