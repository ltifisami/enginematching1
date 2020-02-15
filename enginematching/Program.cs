
using System;
using System.Collections.Generic;

namespace Solution
{


      //enumerator list for the type of order
    public enum Order_type { IOC, GFD, INV, ICB, DRT, BPR };
      // enumerator list for the type of trade
    public enum Operation_type { BUY, SELL, CANCEL, PRINT, MODIFY };
      //enumerator list for Currency
    public enum Devise { EUR,GBD , YEN, CHF, USD,REM_reminbi };
    // enumarator list for UNIT
    public enum Quantity { TONS, UNIT };

    public class Produit
    {
        private string TICKER { get; set; }
        private string Designation { get; set; }
        private Quantity quantity { get; set; }

        public Produit(string tICKER, string designation, Quantity _quantity)
        {
            TICKER = tICKER;
            Designation = designation;
            quantity = _quantity;
        }


    }
    // class Price_delta_range
    public class Price_delta_range
    {

        private int range1;
        private int range2;
        private float price_delta;
        private Devise Devise { set; get; }


        public Price_delta_range(int _range1, int _range2, Devise _devise,float _price_delta)
        {
            range1 = _range1;
            range2 = _range2;
            devise = _devise;
            price_delta = _price_delta;
        }



        public int Range1 { get => range1; set => range1 = value; }
        public  Devise devise{ get ; set ; }
        public int Range2 { get => range2; set => range2 = value; }
        public double Price_delta { get => price_delta; set => price_delta = value; }
    }

    // class trade_table

    public class Trade_table
    {




       


        public int Order_quantity_sell { set; get; }
        public int Order_price_sell { set; get; }
        private Order_type Order_trade_sell { get; set; }
        public string Devise_sell { set; get; }
        public string Country_sell { set; get; }


        public int Order_quantity_buy { set; get; }
        public int Order_price_buy { set; get; }
        private Order_type Order_trade_buy { get => _order_trade_buy; set => _order_trade_buy = value; }
        public string Devise_buy { set; get; }
        public string Country_buy { set; get; }

    }

    public class Settlement_table
    {
        private string tICKER;
        public string Paye_liv { set; get; }
        public string Adresse_liv { set; get; }

        public Settlement_table(string tICKER, string paye_liv, string adresse_liv)
        {
            this.tICKER = tICKER;
            Paye_liv = paye_liv;
            Adresse_liv = adresse_liv;
        }

        public string GetTICKER()
        {
            return tICKER;
        }

        public void SetTICKER(string value)
        {
            tICKER = value;
        }




    }

    public class Buytable
     {
        // à compléter
    }
    public class Selltable 
    {
        // à compléter
    }
    public class Order_table
    {
        private Operation_type Operation_Type { set; get; }



        private int Order_quantity { set; get; }
        private int Order_price { set; get; }

        private Order_type Order_trade { set; get; }



        private Devise devise{ set; get; }
        private string Country { set; get; }
        private TimeSpan ValidityTimePeriode { get; set; }
        private TimeSpan ValidityAbsoluteTime { get; set; }
        private string TICKER { get; set; }
        public DateTime Date_Create_Order { get; set; }


        public Order_table(Operation_type operation_type1, int order_quantity, int order_price, Order_type order_trade, Devise _devise, string country, TimeSpan validityTimePeriode, TimeSpan validityAbsoluteTime, string tICKER)
        {
            Date_Create_Order = DateTime.Now;
            Operation_Type = operation_type1;
            Order_quantity = order_quantity;
            Order_price = order_price;
            Order_trade = order_trade;
            devise = _devise;
            Country = country;
            ValidityTimePeriode = validityTimePeriode;
            ValidityAbsoluteTime = validityAbsoluteTime;
            TICKER = tICKER;
        }

        public Order_table()
        {
        }

        public bool Is_validate_time_periode()
        {
            bool val = true;
            return val;
        }
        public bool Is_validate_absolute_time()
        {
          
            TimeSpan interval = DateTime.Now - this.Date_Create_Order;

            if (this.ValidityAbsoluteTime > interval)
                return true;
            else
                return false;

        }
        public void Description_order()
        {
            Console.WriteLine("le TICKS est "+this.TICKER+
            "\n la  Date_Create_Order est " + this.Date_Create_Order +
               "\nle Type d'operation est " + this.GetOperation_Type() +
            "\n le quantity est " + this.Order_quantity +
               "\n le Order_type est " + this.GetOrder_trade() +
            "\n le  Devise est " + this.devise +
               "\n ValidityTimePeriode est : " + this.ValidityTimePeriode +
            "\n ValidityAbsoluteTime est " + this.ValidityAbsoluteTime
              );

        }
    }

    internal class TradeTable
    {
    }

    internal class SettlementTable
    {
    }

    internal class SellTable
    {
    }

    internal class BuyTable
    {
    }

    // Classe Market 
    public class Market
    {
        public string TICKER { set; get; }

        // fixingPeriod est exprimé en secondes
        private int FixingPeriod { set; get; }

        public DateTime MarketInitDate { get; }
        public int Max_Quantity { set; get; }
        public int Min_Quantity { set; get; }
        public Quantity Description { set; get; }
        public float Price_delta { set; get; }
        public Price_delta_range P_d_r { set; get; }


        private Dictionary<string, BuyTable> buyTable;
        private Dictionary<string, SellTable> sellTable;
        private Dictionary<string, SettlementTable> settlementTable;
        private Dictionary<string, TradeTable> tradeTable;



        // constructeur avec le paramatere FixingPeriod "ADMIN"
        public Market(string tICKER, int fixingPeriod, DateTime marketInitDate, int max_Quantity, int min_Quantity, Quantity description, float price_delta, Price_delta_range p_d_r, Dictionary<string, Order_table> buyTable, Dictionary<string, Order_table> sellTable, Dictionary<string, Order_table> settlementTable, Dictionary<string, Order_table> tradeTable)
        {
            TICKER = tICKER;
            FixingPeriod = fixingPeriod;
            MarketInitDate = marketInitDate;
            Max_Quantity = max_Quantity;
            Min_Quantity = min_Quantity;
            Description = description;
            Price_delta = price_delta;
            P_d_r = p_d_r;
            BuyTable = buyTable;
            SellTable = sellTable;
            SettlementTable = settlementTable;
            TradeTable = tradeTable;
        }

        // Constructeur sans le parametre FixingPeriod
        public Market(string tICKER, DateTime marketInitDate, int max_Quantity, int min_Quantity, Quantity description, float price_delta, Price_delta_range p_d_r, Dictionary<string, Order_table> buyTable, Dictionary<string, Order_table> sellTable, Dictionary<string, Order_table> settlementTable, Dictionary<string, Order_table> tradeTable)
        {
            TICKER = tICKER;
            MarketInitDate = marketInitDate;
            Max_Quantity = max_Quantity;
            Min_Quantity = min_Quantity;
            Description = description;
            Price_delta = price_delta;
            P_d_r = p_d_r;
            BuyTable1 = buyTable;
            SellTable = sellTable;
            SettlementTable = settlementTable;
            TradeTable = tradeTable;
        }
    }


    public class Program
    {

        public static void Main(string[] args)
        {

            Price_delta_range pdr1 = new Price_delta_range(10, 1000,Devise.EUR, 0.5);
            Console.WriteLine(pdr1.Range1);
            Console.WriteLine(pdr1.Range2);
            Console.WriteLine(pdr1.devise);
            Console.WriteLine(pdr1.Price_delta);
            pdr1.Range1 = 20;
            Console.WriteLine(pdr1.Range1);
            Console.WriteLine(Order_type.BPR);
            Console.WriteLine("//////////////////////////////////////////////////////");
            Order_table ot = new Order_table(Operation_type.BUY, 1000, 10, Order_type.GFD, Devise.USD, "USA", new TimeSpan(1,0,0), new TimeSpan(2, 0, 0), "SADERF");

            ot.Description_order();
            if(ot.Is_validate_absolute_time() == true)
            {
                Console.WriteLine("Is_validate_absolute_time");
            }
        }

    }

}
