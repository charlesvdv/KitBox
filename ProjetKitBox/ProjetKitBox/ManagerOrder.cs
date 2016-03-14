﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjetKitBox
{
    public class ManagerOrder
    {
        private MySqlConnection DBCon;

        public ManagerOrder(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}

        //Add an order in the database's order list
        public void Add(Order order)
		{

            //calcute the number of supplement cut of the corner required 
            int supCutNumber = 0;
            foreach(Shelf shelf in order.Shelfs)
            {
                if (shelf.SupplementCut == true)
                {
                    supCutNumber += 1;
                } 
            }

            string query = "INSERT INTO `kitbox`.`commande` (`prix total`, `FK_client`, `date`, `coupeSup`) " +
                "VALUES ('" + order.GetPrice() + "' , '" + order.Client.NClient + "', now(), "+ supCutNumber +");";

            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            cmd.ExecuteNonQuery();

            int PKCommand = Convert.ToInt32(cmd.LastInsertedId);

            //add the linkcommandeelement in the database
            InsertLinkElementCommand(order.GetListElement(), PKCommand);

            //save the state of the element save
            string queryRes = "START TRANSACTION;";
            foreach(Element elem in order.GetListElement())
            {
                queryRes += "update element set reserve = reserve + " +elem.RequiredNumber + " where PK_code = '" +
                    elem.Code + " '; " ;
            }

            queryRes += "COMMIT;";

            cmd = new MySqlCommand(queryRes, DBCon);
            cmd.ExecuteNonQuery();
            DBCon.Close();
        }

        private struct ElemCount
        {
            public Element elem;
            public int num;

            public ElemCount(Element e, int num)
            {
                this.elem = e;
                this.num = num;
            }

        }

        private void InsertLinkElementCommand(List<Element> elems, int PKCommand)
        {
            List<ElemCount> SortedElem = new List<ElemCount>() { };

            foreach(Element e in elems)
            {
                if (elems.Exists(x => x.Code == e.Code))
                {
                    int index = SortedElem.FindIndex(x => x.elem.Code == e.Code);

                    ElemCount elemCount = SortedElem[index];
                    elemCount.num += e.RequiredNumber;
                }
                else
                {
                    SortedElem.Add(new ElemCount(e, e.RequiredNumber));
                }
            }

            string query = "START TRANSACTION; ";
            foreach (ElemCount ec in SortedElem)
            {
                query += "insert into linkcommandeelement ('FK_Element', 'FK_commande', 'quantiteTotale', 'prix', 'quantiteRetiree') " +
                    " values ('" + ec.elem.Code +"','"+ PKCommand+"', '"+ ec.num+"', '"+ec.elem.Price+"', 0); ";
            }
            query += "COMMIT; ";

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            cmd.ExecuteNonQuery();

        }

        //Retrun a list of comanded number for each element in the past six month 
        public List<StructOrder> GetSaleStatistic()
		{
            string query = "select e.PK_code, e.typeElement, e.couleur, e.hauteur, e.largeur, e.profondeur, e.prix, e.nbrpieces, " +
                "sum(l.quantiteTotale) as tot from element e " +
                "inner join linkcommandeelement l on e.PK_code = l.FK_element " +
                "inner join commande on l.FK_commande = commande.PK_refCommande where commande.date " + 
                "between now() - interval 6 month and now() group by e.PK_code;";

            try
            {
                DBCon.Open();
            } catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

             MySqlDataReader dataReader = cmd.ExecuteReader();

            List<StructOrder> data = new List<StructOrder>() { };         
            
            while(dataReader.Read())
            {
                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);
                Element e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                    (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                StructOrder eOrd = new StructOrder(e, Convert.ToInt32(dataReader["tot"]));

                data.Add(eOrd);  
            }

            dataReader.Close();
            DBCon.Close();

            return data; 
		}

    }
}
