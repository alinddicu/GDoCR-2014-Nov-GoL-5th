using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class Cellule
    {
        public EtatCellule Etat { get; private set; }

        private int _nbVoisinsVivants;

        public event Action NaissanceEvent;

        public event Action MortEvent;

        public Cellule(EtatCellule etat = EtatCellule.Mort)
        {
            Etat = etat;
        }

        private void Cellule_NaissanceEvent()
        {
            _nbVoisinsVivants++;
        }

        private void Cellule_MortEvent()
        {
            _nbVoisinsVivants--;
        }

        public void AjouterVoisinVivant(Cellule cellule)
        {
            _nbVoisinsVivants++;
            cellule.NaissanceEvent += Cellule_NaissanceEvent;
            cellule.MortEvent += Cellule_MortEvent;
        }

        public void AjouterVoisinMort(Cellule cellule)
        {
            cellule.NaissanceEvent += Cellule_NaissanceEvent;
            cellule.MortEvent += Cellule_MortEvent;
        }

        public void Muter()
        {
            var nouvelEtat = EtatCellule.Mort;
            if (Etat == EtatCellule.Vivant && (_nbVoisinsVivants == 2 || _nbVoisinsVivants == 3))
            {
                nouvelEtat = EtatCellule.Vivant;
            }
            else if (Etat == EtatCellule.Mort && _nbVoisinsVivants == 3)
            {
                nouvelEtat = EtatCellule.Vivant;
            }

            if (Etat != nouvelEtat)
            {
                Etat = nouvelEtat;
                if (Etat == EtatCellule.Vivant)
                {
                    NaissanceEvent();
                }
                else
                {
                    MortEvent();
                }
            }
        }
    }
}
