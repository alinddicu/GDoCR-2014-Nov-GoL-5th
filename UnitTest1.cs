using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EtantDonneUneCelluleVivanteEt2VoisinesVivantesQuandElleMuteElleResteEnVie()
        {
            var cellule1 = new Cellule(EtatCellule.Vivant);
            var cellule2 = new Cellule(EtatCellule.Vivant);
            var cellule3 = new Cellule(EtatCellule.Vivant);
            var cellule4 = new Cellule();

            cellule1.AjouterVoisinVivant(cellule2);
            cellule1.AjouterVoisinVivant(cellule3);
            cellule1.AjouterVoisinMort(cellule4);

            cellule2.AjouterVoisinVivant(cellule1);
            cellule2.AjouterVoisinVivant(cellule3);
            cellule2.AjouterVoisinMort(cellule4);

            cellule3.AjouterVoisinVivant(cellule1);
            cellule3.AjouterVoisinVivant(cellule2);
            cellule3.AjouterVoisinMort(cellule4);

            cellule4.AjouterVoisinVivant(cellule1);
            cellule4.AjouterVoisinVivant(cellule2);
            cellule4.AjouterVoisinVivant(cellule3);

            cellule1.Muter();
            cellule2.Muter();
            cellule3.Muter();
            cellule4.Muter();

            Assert.IsTrue(cellule1.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule2.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule3.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule4.Etat == EtatCellule.Vivant);

            cellule1.Muter();
            cellule2.Muter();
            cellule3.Muter();
            cellule4.Muter();

            Assert.IsTrue(cellule1.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule2.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule3.Etat == EtatCellule.Vivant);
            Assert.IsTrue(cellule4.Etat == EtatCellule.Vivant);
        }
    }
}
