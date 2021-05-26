#include <SPI.h>
#include <MFRC522.h>
 
#define SS_PIN 10
#define RST_PIN 9
MFRC522 mfrc522(SS_PIN, RST_PIN);   
MFRC522::MIFARE_Key key;
MFRC522::StatusCode status;

byte readBlockData[18];
byte bufferLen = 18;

#define bloccoNome 4
#define bloccoCognome 5
#define bloccoID 6
#define bloccoAbbonamento 8
#define bloccoFineAbbonamento 9
#define bloccoCredito 10
#define numeriBlocchi 6
int VettoreNumeriBlocchi[numeriBlocchi] = {bloccoNome, bloccoCognome, bloccoID, bloccoAbbonamento, bloccoFineAbbonamento, bloccoCredito};

String UID, stringaSeriale, accesso;

#define ledVerde 6
#define ledRosso 5
#define Buzzer 7
 
void setup() 
{
  SPI.begin();      // Si inizializza il canale SPI
  mfrc522.PCD_Init();   // Si inizializza la scheda NFC (MFRC522)

  Serial.begin(9600);

  pinMode(ledVerde, OUTPUT);
  pinMode(ledRosso, OUTPUT);
  pinMode(Buzzer, OUTPUT);
  
  /*Serial.println("Setup Completato...");
  Serial.println();*/
}

void loop() 
{
  /* Preparo la tessera per la lettura e la scrittura dei dati*/
  for (byte i = 0; i < 6; i++) key.keyByte[i] = 0xFF;
  
  /* Verifico la presenza di una nuova scheda */
  if ( ! mfrc522.PICC_IsNewCardPresent()) return;
  /* Seleziono una delle schede lette */
  if ( ! mfrc522.PICC_ReadCardSerial()) return;

  /* Salvo l'ID della scheda letta al ciclo precedente e leggo il nuovo ID della scheda */
  String UID_Precedente = UID;
  UID = "";
  for (byte i = 0; i < mfrc522.uid.size; i++) 
  {
     UID.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
     UID.concat(String(mfrc522.uid.uidByte[i], HEX));
  }
  /* Per semplicità di confronto, porto maiuscoli tutti i caratteri */
  UID.toUpperCase();

  /* Verifico se l'ID è uguale a quello letto nel ciclo precedente, se è uguale salto il ciclo */
  if (UID == UID_Precedente) return;
  else {
    stringaSeriale = "";
    for(int i = 0; i < numeriBlocchi; i++){
      ReadDataFromBlock(VettoreNumeriBlocchi[i], readBlockData);
      stringaSeriale.concat(String((char*)readBlockData) + ";");
    }
    Serial.println(stringaSeriale);

    /* Stampa dati badge */
    /*WriteAllCardData();*/

    /* Reset canali con Badge MiFare*/
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
  }

  /* Aspetto dei dati sulla porta seriale e li leggo */
  while (Serial.available() == 0);
  accesso = Serial.readStringUntil(';');
  OutputAccesso();
}
