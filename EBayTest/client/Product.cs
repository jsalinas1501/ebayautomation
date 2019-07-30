using System;
using System.Collections.Generic;
using System.Text;

namespace EBayTest.client
{
    class Product
    {
        private string title;
        private string price;

        public String GetTitle()
        {
            return title;
        } 

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public String GetPrice()
        {
            return price;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }

    }
}
