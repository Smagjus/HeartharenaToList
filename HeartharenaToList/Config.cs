using System;
using System.Collections.Generic;
using System.Text;

namespace HeartharenaToList
{
    public class Config
    {
        public string CardList = "//ul[@class='deckList']/li";
        public string SingleCard = "child::span[@class='name']";


        public void CreateNew()
        {
        }

        public void Save()
        {

        }

        public bool IfConfigExist()
        {

            return false;
        }
    }
}
