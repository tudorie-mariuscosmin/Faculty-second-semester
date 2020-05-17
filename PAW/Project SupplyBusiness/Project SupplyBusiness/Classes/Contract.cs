﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SupplyBusiness.Classes
{
    [Serializable]
  public  class Contract
    {
        static int noObjects = 0;


        public int ContractNo { get; set; }
        public string ClientName { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientBank { get; set; }
        public Supplier Supplier { get; set; }
        private int GoodIndex { get; set; }
        public int NoGoods { get; set; }
        public double totalGoods { get;  set; }
        public double totalTax { get;  set; }
        public double totalPrice { get;  set; }
        public Good orderedGood { get;  set; }
        public DateTime Date { get; set; }

        public Contract() { }
        public Contract(string clientName, string clientPhoneNumber, string clientBank, Supplier supplier, int goodIndex, int noGoods)
        {
            ContractNo = noObjects;
            noObjects++;
            ClientName = clientName;
            ClientPhoneNumber = clientPhoneNumber;
            ClientBank = clientBank;
            Supplier = supplier;
            GoodIndex = goodIndex;
            NoGoods = noGoods;

            orderedGood = Supplier.Goods[GoodIndex];

            totalGoods = orderedGood.Price * NoGoods;
            totalTax = orderedGood.Tax * NoGoods;
            totalPrice = totalGoods + totalTax;

            Date = DateTime.Now;
        }
    }
}