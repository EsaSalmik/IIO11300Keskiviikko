/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 20.1.2016 
* Authors: Esa Salmikangas
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class IkkunaVE0
    {
        //tehdään public, ÄLÄ käytä! Edustaa "huonoa" ohjelmointitapaa
        //QUICK and DIRTY
        public double leveys;
        public double korkeus;
        public double LaskePintaala()
        {
            return leveys * korkeus;
        }
    }
    public class Ikkuna
    {
        //Properties
        //property = Ominaisuus
        //parempi tapa on avata "hallitusti" olio ominaisuuksien kautta
        private double korkeus;

        public double Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }
        private double leveys;

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }
        //read-only tyyppinen property
        public double PintaAla
        {
            get
            {
                //return korkeus * leveys;
                return LaskeIPintaala();
            }
        }
        //Metodit
        public double LaskePintaAla()
        {
            //return korkeus * leveys;
            return LaskeIPintaala();
        }
        private double LaskeIPintaala()
        {
            return korkeus * leveys;
        }
    }
}
