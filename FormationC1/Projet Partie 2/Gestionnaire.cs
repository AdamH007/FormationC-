﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    class Gestionnaire
    {
        public enum TypeGestionnaire
        {
            Particulier,
            Entreprise
        }

        public uint Id { get; set; }
        public TypeGestionnaire Type { get; set; }
        public uint NombreTransMax { get; set; }

        public double CalculerFraisGestion(List<Compte> comptesGerés)
        {
            switch (Type)
            {
                case TypeGestionnaire.Particulier:
                    return 5.0;
                case TypeGestionnaire.Entreprise:
                    double total = comptesGerés.Sum(c => c.Solde);
                    return total * 0.005;
                default:
                    return 0.0;
            }
        }

        public Gestionnaire(uint id, string nom, TypeGestionnaire type)
        {
            Id = id;
            NombreTransMax = nombreTransMax;
            Type = type;
        }

    }
}
