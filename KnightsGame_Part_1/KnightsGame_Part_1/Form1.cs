using System;                           // Verwendung des Systems
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;                   //  alle blass hinterlegten using-Anweisungen wurden zwar auch automatisch erzeugt, sind jedoch unnötig und deswegen auch deaktiviert
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;             // Verwendung von grafischen Benutzeroberflächen (GUIs) und Formularen sowie den dazugehörigen Komponenten (Werkzeugen)

namespace KnightsGame_Part_1            // Projektbezeichnung
{
    public partial class fm_KnightsGame_1 : Form    // Formular zur grafischen Benutzerschnittstelle (GUI - graphical user interface) KnightsGame als öffentliche Teil-/Unterklasse
    {
        public fm_KnightsGame_1()                   // öffentliche Klasse (public) KnightsGame (Ritterspiel_1)
        {
            InitializeComponent();					// Komponenten der Klasse werden initialisiert
        }

     // Funktion zum Erzeugen bzw. Laden des Formulars zur grafischen Benutzerschnittstelle (GUI - graphical user interface)
     private void fm_KnightsGame_1_Load(object sender, EventArgs e)
     {
            tB_diceNumber.ReadOnly = true;  // Eingabefeld (Textbox) für die Würfelzahl enthält nur Leserechte (Es darf nichts eingetragen werden.)
         // Als Erster ist immer Ritter 1 dran
			bt_knight1.Enabled = true;      // Schaltfläche (Button) für Ritter 1 ist aktiviert.
            bt_knight2.Enabled = false;     // Schaltfläche (Button) für Ritter 2 ist deaktiviert.
            bt_knight3.Enabled = false;     // Schaltfläche (Button) für Ritter 3 ist deaktiviert.
            bt_knight4.Enabled = false;     // Schaltfläche (Button) für Ritter 4 ist deaktiviert.
            bt_knight5.Enabled = false;     // Schaltfläche (Button) für Ritter 5 ist deaktiviert.     
     }

    // Festlegen der Energiepunkte für jeden der 5 Ritter als globale Variablen, da sonst die darauffolgenden Button-OnClick-Events (Ereignisse) nur einmal
    // ausgeführt werden und eine Schleife alle Zwischenschritte automatisch durchgeht, sodass am Ende nur das Ergebnis des letztmöglichen Schrittes angezeigt wird  
    // Jeder Ritter hat anfangs 100 Energiepunkte.
        int energyPoints_Knight_1 = 100;
        int energyPoints_Knight_2 = 100;
        int energyPoints_Knight_3 = 100;
        int energyPoints_Knight_4 = 100;
        int energyPoints_Knight_5 = 100;


    // Funktion während eines Button-OnClick-Events beim Klick auf den Button bt_knight1 -> Ritter 1 ist mit Würfeln dran
        private void bt_knight1_Click(object sender, EventArgs e)
        {
            Random random = new Random();               // Erzeugen eines Zufallsgenerators als Objekt
            int diceNumber = random.Next(1, 7);         // Würfelzahl wird bei jedem Buttonklick als Zufallszahl zwischen 1 und 6 generiert, Endwert 7, weil bei Endwert 6 nur 1-5
            tB_diceNumber.Text = diceNumber.ToString(); // Würfelzahl wird als ganzzahliger int-Wert in Textbox übetragen und dort als String (Zeichenkette) umgewandelt ausgegeben
            
			bt_knight1.Enabled = false;                 // bt_knight1 wird deaktiviert
            energyPoints_Knight_2 -= diceNumber;        // Ritter 2 wird die vom Ritter 1 gewürfelte Menge der Energiepunkte entnommen

            if (energyPoints_Knight_2 > 0)  // wenn Ritter 2 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
            {
                bt_knight2.Enabled = true;                          // bt_knight2 wird aktiviert
                bt_knight2.Text = energyPoints_Knight_2.ToString(); // Anzahl der verbliebenen Energiepunkte von Ritter 2 wird auf bt_knight2 als String umgewandelt ausgegeben.
            }

            else                            // sonst (wenn Ritter 2 keine Energiepunkte mehr hat und somit tot ist)                                            
            {
                bt_knight2.Text = "0";      // Selbst, wenn es durch die Würfelzahl zu einem negativen Ergebnis gekommen wäre, gibt bt_knight2 den Wert 0 als String aus.
                bt_knight2.Enabled = false; // bt_knight2 wird deaktiviert

                if (int.Parse(bt_knight3.Text) > 0)                                 // wenn Ritter 3 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight3.Enabled = true;                                      // bt_knight3 wird aktiviert
                    energyPoints_Knight_3 -= diceNumber;                            // Ritter 3 wird die vom Ritter 1 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_3 <= 0) { bt_knight3.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight3 ebenfalls 0 aus -> Ritter 3 ist tot
                    else { bt_knight3.Text = energyPoints_Knight_3.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 3 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight4.Text) > 0)                            // sonst: wenn Ritter 4 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight4.Enabled = true;                                      // bt_knight4 wird aktiviert
                    energyPoints_Knight_4 -= diceNumber;                            // Ritter 4 wird die vom Ritter 1 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_4 <= 0) { bt_knight4.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight4 ebenfalls 0 aus -> Ritter 4 ist tot
                    else { bt_knight4.Text = energyPoints_Knight_4.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 4 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight5.Text) > 0)                            // sonst: wenn Ritter 5 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight5.Enabled = true;                                      // bt_knight5 wird aktiviert
                    energyPoints_Knight_5 -= diceNumber;                            // Ritter 5 wird die vom Ritter 1 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_5 <= 0) { bt_knight5.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight5 ebenfalls 0 aus -> Ritter 5 ist tot
                    else { bt_knight5.Text = energyPoints_Knight_5.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 5 als String ausgegeben
                }

                else if (int.Parse(bt_knight1.Text) > 0)  	  // sonst: wenn Ritter 1 selbst mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {                                             // (Kein Ritter kann sich selbst Energie entnehmen und damit auch töten.)
                    MessageBox.Show("Knight 1 has won.");     // Hinweisfenster angezeigt: Ritter 1 hat gewonnen, da alle anderen Ritter tot sind
                    MessageBox.Show("Game over!");            // weiteres Hinweisfenster (MessageBox): Spiel ist damit zu Ende -> Schließen eines Hinweisfensters mit Klick auf OK
                    bt_knight1.Enabled = true;                // Gewinner-Button bt_knight1 wird aktiviert, jedoch werden nach dem Spielende bei jedem Klick immer nur                                                            
                }                                             // die beiden Hinweisfenster zum Sieg von Ritter 1 bzw. Ende des Spiels angezeigt
            } // else (if energyPoints_Knight_2) <= 0) 
        } // private void bt_knight1_Click

     
     // Funktion während eines Button-OnClick-Events beim Klick auf den Button bt_knight2 -> Ritter 2 ist mit Würfeln dran
     private void bt_knight2_Click(object sender, EventArgs e)
        {
            Random random = new Random();               // Erzeugen eines Zufallsgenerators als Objekt
            int diceNumber = random.Next(1, 7);         // Würfelzahl wird bei jedem Buttonklick als Zufallszahl zwischen 1 und 6 generiert, Endwert 7, weil bei Endwert 6 nur 1-5
            tB_diceNumber.Text = diceNumber.ToString(); // Würfelzahl wird als ganzzahliger int-Wert in Textbox übetragen und dort als String (Zeichenkette) umgewandelt ausgegeben   
            
			bt_knight2.Enabled = false;                 // bt_knight2 wird deaktiviert
            energyPoints_Knight_3 -= diceNumber;        // Ritter 3 wird die vom Ritter 2 gewürfelte Menge der Energiepunkte entnommen

            if (energyPoints_Knight_3 > 0)              // wenn Ritter 3 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
            {
                bt_knight3.Enabled = true;                          // bt_knight3 wird aktiviert
                bt_knight3.Text = energyPoints_Knight_3.ToString(); // Anzahl der verbliebenen Energiepunkte von Ritter 3 wird auf bt_knight3 als String umgewandelt ausgegeben.
            }

            else                            // sonst (wenn Ritter 3 keine Energiepunkte mehr hat und somit tot ist) 
            {
                bt_knight3.Text = "0";      // Selbst, wenn es durch die Würfelzahl zu einem negativen Ergebnis gekommen wäre, gibt bt_knight3 den Wert 0 als String aus.
                bt_knight3.Enabled = false; // bt_knight3 wird deaktiviert

                if (int.Parse(bt_knight4.Text) > 0)                                // sonst: wenn Ritter 4 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight4.Enabled = true;                                     // bt_knight4 wird aktiviert
                    energyPoints_Knight_4 -= diceNumber;                           // Ritter 4 wird die vom Ritter 2 gewürfelte Menge der Energiepunkte entnommen 

                    if (energyPoints_Knight_4 <= 0) { bt_knight4.Text = "0"; }     // im Falle eines negativen Ergebnisses gibt bt_knight4 ebenfalls 0 aus -> Ritter 4 ist tot 
                    else { bt_knight4.Text = energyPoints_Knight_4.ToString(); }   // anderenfalls werden die verbliebenen Energiepunkte von Ritter 4 als String ausgegeben
                }

                else if (int.Parse(bt_knight5.Text) > 0)                            // sonst: wenn Ritter 5 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight5.Enabled = true;                                      // bt_knight5 wird aktiviert
                    energyPoints_Knight_5 -= diceNumber;                            // Ritter 5 wird die vom Ritter 2 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_5 <= 0) { bt_knight5.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight5 ebenfalls 0 aus -> Ritter 5 ist tot
                    else { bt_knight5.Text = energyPoints_Knight_5.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 5 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight1.Text) > 0)                            // sonst: wenn Ritter 1 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight1.Enabled = true;                                      // bt_knight1 wird aktiviert
                    energyPoints_Knight_1 -= diceNumber;                            // Ritter 1 wird die vom Ritter 2 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_1 <= 0) { bt_knight1.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight1 ebenfalls 0 aus -> Ritter 1 ist tot
                    else { bt_knight1.Text = energyPoints_Knight_1.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 1 als String ausgegeben                
                }

                else if (int.Parse(bt_knight2.Text) > 0)    // sonst: wenn Ritter 2 selbst mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {                                           // (Kein Ritter kann sich selbst Energie entnehmen und damit auch töten.)
                    MessageBox.Show("Knight 2 has won.");   // Hinweisfenster angezeigt: Ritter 2 hat gewonnen, da alle anderen Ritter tot sind
                    MessageBox.Show("Game over!");          // weiteres Hinweisfenster (MessageBox): Spiel ist damit zu Ende -> Schließen eines Hinweisfensters mit Klick auf OK
                    bt_knight2.Enabled = true;              // Gewinner-Button bt_knight2 wird aktiviert, jedoch werden nach dem Spielende bei jedem Klick immer nur
                }                                           // die beiden Hinweisfenster zum Sieg von Ritter 2 bzw. Ende des Spiels angezeigt
            } // else (if (energyPoints_Knight_3 <= 0))    
        }  // private void bt_knight2_Click 


     // Funktion während eines Button-OnClick-Events beim Klick auf den Button bt_knight3 -> Ritter 3 ist mit Würfeln dran
        private void bt_knight3_Click(object sender, EventArgs e)
        {
            Random random = new Random();               // Erzeugen eines Zufallsgenerators als Objekt
            int diceNumber = random.Next(1, 7);         // Würfelzahl wird bei jedem Buttonklick als Zufallszahl zwischen 1 und 6 generiert, Endwert 7, weil bei Endwert 6 nur 1-5
            tB_diceNumber.Text = diceNumber.ToString(); // Würfelzahl wird als ganzzahliger int-Wert in Textbox übetragen und dort als String (Zeichenkette) umgewandelt ausgegeben    
            
			bt_knight3.Enabled = false;                 // bt_knight3 wird deaktiviert
            energyPoints_Knight_4 -= diceNumber;        // Ritter 4 wird die vom Ritter 3 gewürfelte Menge der Energiepunkte entnommen

            if (energyPoints_Knight_4 > 0)              // wenn Ritter 4 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
            {
                bt_knight4.Enabled = true;                          // bt_knight4 wird aktiviert
                bt_knight4.Text = energyPoints_Knight_4.ToString(); // Anzahl der verbliebenen Energiepunkte von Ritter 4 wird auf bt_knight4 als String umgewandelt ausgegeben.
            }

            else                            // sonst (wenn Ritter 4 keine Energiepunkte mehr hat und somit tot ist) 
            {
                bt_knight4.Text = "0";      // Selbst, wenn es durch die Würfelzahl zu einem negativen Ergebnis gekommen wäre, gibt bt_knight4 den Wert 0 als String aus.
                bt_knight4.Enabled = false; // bt_knight4 wird deaktiviert

                if (int.Parse(bt_knight5.Text) > 0)                                // sonst: wenn Ritter 5 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight5.Enabled = true;                                     // bt_knight5 wird aktiviert
                    energyPoints_Knight_5 -= diceNumber;                           // Ritter 5 wird die vom Ritter 3 gewürfelte Menge der Energiepunkte entnommen 

                    if (energyPoints_Knight_5 <= 0) { bt_knight5.Text = "0"; }     // im Falle eines negativen Ergebnisses gibt bt_knight5 ebenfalls 0 aus -> Ritter 5 ist tot 
                    else { bt_knight5.Text = energyPoints_Knight_5.ToString(); }   // anderenfalls werden die verbliebenen Enrgiepunkte von Ritter 5 als String ausgegeben
                }

                else if (int.Parse(bt_knight1.Text) > 0)                            // sonst: wenn Ritter 1 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight1.Enabled = true;                                      // bt_knight1 wird aktiviert
                    energyPoints_Knight_1 -= diceNumber;                            // Ritter 1 wird die vom Ritter 3 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_1 <= 0) { bt_knight1.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight1 ebenfalls 0 aus -> Ritter 1 ist tot
                    else { bt_knight1.Text = energyPoints_Knight_1.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 1 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight2.Text) > 0)                            // sonst: wenn Ritter 2 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight2.Enabled = true;                                      // bt_knight2 wird aktiviert
                    energyPoints_Knight_2 -= diceNumber;                            // Ritter 2 wird die vom Ritter 3 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_2 <= 0) { bt_knight2.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight2 ebenfalls 0 aus -> Ritter 2 ist tot
                    else { bt_knight2.Text = energyPoints_Knight_2.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 2 als String ausgegeben                
                }

                else if (int.Parse(bt_knight3.Text) > 0)    // sonst: wenn Ritter 3 selbst mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {                                           // (Kein Ritter kann sich selbst Energie entnehmen und damit auch töten.)
                    MessageBox.Show("Knight 3 has won.");   // Hinweisfenster angezeigt: Ritter 3 hat gewonnen, da alle anderen Ritter tot sind
                    MessageBox.Show("Game over!");          // weiteres Hinweisfenster (MessageBox): Spiel ist damit zu Ende -> Schließen eines Hinweisfensters mit Klick auf OK
                    bt_knight3.Enabled = true;              // Gewinner-Button bt_knight3 wird aktiviert, jedoch werden nach dem Spielende bei jedem Klick immer nur
                }                                           // die beiden Hinweisfenster zum Sieg von Ritter 3 bzw. Ende des Spiels angezeigt 
            } // else (if (energyPoints_Knight_4 <= 0))   
        } // private void bt_knight3_Click

        
    // Funktion während eines Button-OnClick-Events beim Klick auf den Button bt_knight4 -> Ritter 4 ist mit Würfeln dran
        private void bt_knight4_Click(object sender, EventArgs e)
        {
            Random random = new Random();               // Erzeugen eines Zufallsgenerators als Objekt
            int diceNumber = random.Next(1, 7);         // Würfelzahl wird bei jedem Buttonklick als Zufallszahl zwischen 1 und 6 generiert, Endwert 7, weil bei Endwert 6 nur 1-5
            tB_diceNumber.Text = diceNumber.ToString(); // Würfelzahl wird als ganzzahliger int-Wert in Textbox übetragen und dort als String (Zeichenkette) umgewandelt ausgegeben    
            
			bt_knight4.Enabled = false;                 // bt_knight4 wird deaktiviert
            energyPoints_Knight_5 -= diceNumber;        // Ritter 5 wird die vom Ritter 4 gewürfelte Menge der Energiepunkte entnommen

            if (energyPoints_Knight_5 > 0)              // wenn Ritter 5 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
            {
                bt_knight5.Enabled = true;                          // bt_knight5 wird aktiviert
                bt_knight5.Text = energyPoints_Knight_5.ToString(); // Anzahl der verbliebenen Energiepunkte von Ritter 5 wird auf bt_knight5 als String umgewandelt ausgegeben.
            }

            else                            // sonst (wenn Ritter 5 keine Energiepunkte mehr hat und somit tot ist) 
            {
                bt_knight5.Text = "0";      // Selbst, wenn es durch die Würfelzahl zu einem negativen Ergebnis gekommen wäre, gibt bt_knight5 den Wert 0 als String aus.
                bt_knight5.Enabled = false; // bt_knight5 wird deaktiviert

                if (int.Parse(bt_knight1.Text) > 0)                                // sonst: wenn Ritter 1 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight1.Enabled = true;                                     // bt_knight1 wird aktiviert
                    energyPoints_Knight_1 -= diceNumber;                           // Ritter 1 wird die vom Ritter 4 gewürfelte Menge der Energiepunkte entnommen 

                    if (energyPoints_Knight_1 <= 0) { bt_knight1.Text = "0"; }     // im Falle eines negativen Ergebnisses gibt bt_knight1 ebenfalls 0 aus -> Ritter 1 ist tot 
                    else { bt_knight1.Text = energyPoints_Knight_1.ToString(); }   // anderenfalls werden die verbliebenen Energiepunkte von Ritter 1 als String ausgegeben
                }

                else if (int.Parse(bt_knight2.Text) > 0)                            // sonst: wenn Ritter 2 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight2.Enabled = true;                                      // bt_knight2 wird aktiviert
                    energyPoints_Knight_2 -= diceNumber;                            // Ritter 2 wird die vom Ritter 4 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_2 <= 0) { bt_knight2.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight2 ebenfalls 0 aus -> Ritter 2 ist tot
                    else { bt_knight2.Text = energyPoints_Knight_2.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 2 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight3.Text) > 0)                            // sonst: wenn Ritter 3 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight3.Enabled = true;                                      // bt_knight3 wird aktiviert
                    energyPoints_Knight_3 -= diceNumber;                            // Ritter 3 wird die vom Ritter 4 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_3 <= 0) { bt_knight3.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight3 ebenfalls 0 aus -> Ritter 3 ist tot
                    else { bt_knight3.Text = energyPoints_Knight_3.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 3 als String ausgegeben                
                }

                else if (int.Parse(bt_knight4.Text) > 0)    // sonst: wenn Ritter 4 selbst mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {                                           // (Kein Ritter kann sich selbst Energie entnehmen und damit auch töten.)
                    MessageBox.Show("Knight 4 has won.");   // Hinweisfenster angezeigt: Ritter 4 hat gewonnen, da alle anderen Ritter tot sind
                    MessageBox.Show("Game over!");          // weiteres Hinweisfenster (MessageBox): Spiel ist damit zu Ende -> Schließen eines Hinweisfensters mit Klick auf OK
                    bt_knight4.Enabled = true;              // Gewinner-Button bt_knight4 wird aktiviert, jedoch werden nach dem Spielende bei jedem Klick immer nur
                }                                           // die beiden Hinweisfenster zum Sieg von Ritter 4 bzw. Ende des Spiels angezeigt 
            } // else (if (energyPoints_Knight_5 <= 0))
        } // private void bt_Knight4_Click


     // Funktion während eines Button-OnClick-Events beim Klick auf den Button bt_knight5 -> Ritter 5 ist mit Würfeln dran
        private void bt_knight5_Click(object sender, EventArgs e)
        {
            Random random = new Random();               // Erzeugen eines Zufallsgenerators als Objekt
            int diceNumber = random.Next(1, 7);         // Würfelzahl wird bei jedem Buttonklick als Zufallszahl zwischen 1 und 6 generiert, Endwert 7, weil bei Endwert 6 nur 1-5
            tB_diceNumber.Text = diceNumber.ToString(); // Würfelzahl wird als ganzzahliger int-Wert in Textbox übetragen und dort als String (Zeichenkette) umgewandelt ausgegeben    
            
			bt_knight5.Enabled = false;                 // bt_knight5 wird deaktiviert
            energyPoints_Knight_1 -= diceNumber;        // Ritter 1 wird die vom Ritter 5 gewürfelte Menge der Energiepunkte entnommen

            if (energyPoints_Knight_1 > 0)              // wenn Ritter 1 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
            {
                bt_knight1.Enabled = true;                          // bt_knight1 wird aktiviert
                bt_knight1.Text = energyPoints_Knight_1.ToString(); // Anzahl der verbliebenen Energiepunkte von Ritter 1 wird auf bt_knight1 als String umgewandelt ausgegeben.
            }

            else                            // sonst (wenn Ritter 1 keine Energiepunkte mehr hat und somit tot ist) 
            {
                bt_knight1.Text = "0";      // Selbst, wenn es durch die Würfelzahl zu einem negativen Ergebnis gekommen wäre, gibt bt_knight1 den Wert 0 als String aus.
                bt_knight1.Enabled = false; // bt_knight1 wird deaktiviert

                if (int.Parse(bt_knight2.Text) > 0)                                // sonst: wenn Ritter 2 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight2.Enabled = true;                                     // bt_knight2 wird aktiviert
                    energyPoints_Knight_2 -= diceNumber;                           // Ritter 2 wird die vom Ritter 5 gewürfelte Menge der Energiepunkte entnommen 

                    if (energyPoints_Knight_2 <= 0) { bt_knight2.Text = "0"; }     // im Falle eines negativen Ergebnisses gibt bt_knight2 ebenfalls 0 aus -> Ritter 2 ist tot 
                    else { bt_knight2.Text = energyPoints_Knight_2.ToString(); }   // anderenfalls werden die verbliebenen Energiepunkte von Ritter 2 als String ausgegeben
                }

                else if (int.Parse(bt_knight3.Text) > 0)                            // sonst: wenn Ritter 3 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight3.Enabled = true;                                      // bt_knight3 wird aktiviert
                    energyPoints_Knight_5 -= diceNumber;                            // Ritter 3 wird die vom Ritter 5 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_3 <= 0) { bt_knight3.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight3 ebenfalls 0 aus -> Ritter 3 ist tot
                    else { bt_knight3.Text = energyPoints_Knight_3.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 3 als String ausgegeben                           
                }

                else if (int.Parse(bt_knight4.Text) > 0)                            // sonst: wenn Ritter 4 mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {
                    bt_knight4.Enabled = true;                                      // bt_knight4 wird aktiviert
                    energyPoints_Knight_4 -= diceNumber;                            // Ritter 4 wird die vom Ritter 5 gewürfelte Menge der Energiepunkte entnommen

                    if (energyPoints_Knight_4 <= 0) { bt_knight4.Text = "0"; }      // im Falle eines negativen Ergebnisses gibt bt_knight4 ebenfalls 0 aus -> Ritter 4 ist tot
                    else { bt_knight4.Text = energyPoints_Knight_4.ToString(); }    // anderenfalls werden die verbliebenen Energiepunkte von Ritter 4 als String ausgegeben                
                }

                else if (int.Parse(bt_knight5.Text) > 0)    // sonst: wenn Ritter 5 selbst mehr als 0 Energiepunkte hat und damit noch im Spiel ist
                {                                           // (Kein Ritter kann sich selbst Energie entnehmen und damit auch töten.)
                    MessageBox.Show("Knight 5 has won.");   // Hinweisfenster angezeigt: Ritter 5 hat gewonnen, da alle anderen Ritter tot sind
                    MessageBox.Show("Game over!");          // weiteres Hinweisfenster (MessageBox): Spiel ist damit zu Ende -> Schließen eines Hinweisfensters mit Klick auf OK
                    bt_knight5.Enabled = true;              // Gewinner-Button bt_knight5 wird aktiviert, jedoch werden nach dem Spielende bei jedem Klick immer nur
                }                                           // die beiden Hinweisfenster zum Sieg von Ritter 5 bzw. Ende des Spiels angezeigt
            } // else (if (energyPoints_Knight_1 <= 0))  
        } // private void bt_knight5_Click

        
    } // public partial class KnightsGame_1 : Form (Formular zur GUI KnightsGame1 als öffentliche Teilklasse)

} // namespace KnightsGame_Part_1 (Projektbezeichnung)
