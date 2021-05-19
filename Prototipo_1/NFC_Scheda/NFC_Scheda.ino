#include <SPI.h>
#include <MFRC522.h>
 
#define SS_PIN 10
#define RST_PIN 9
MFRC522 mfrc522(SS_PIN, RST_PIN);   
MFRC522::MIFARE_Key key;
MFRC522::StatusCode status;

/*
byte blockDataNome[16] = {"Daniele"};
byte blockDataCognome[16] = {"Roncoroni"};
byte blockDataID[16] = {"15"};
byte blockDataAbbonamento[16] = {"2"};
byte blockDataFineAbbonamento[16] = {"20210615"};
byte blockDataCredito[16] = {"23"};
*/
byte readBlockData[18];
byte bufferLen = 18;


String UID = "";
#define bloccoNome 4
#define bloccoCognome 5
#define bloccoID 6
#define bloccoAbbonamento 8 //0 no, 1 settimanale, 2 mensile, 3 annuale
#define bloccoFineAbbonamento 9 //data in formato aaaammgg
#define bloccoCredito 10
#define numeriBlocchi 6
int VettoreNumeriBlocchi[numeriBlocchi] = {bloccoNome, bloccoCognome, bloccoID, bloccoAbbonamento, bloccoFineAbbonamento, bloccoCredito};

String stringaSeriale = "";
String accesso = "";

#define ledVerde 6
#define ledRosso 5
#define Buzzer 7
 
void setup() 
{
  pinMode(ledVerde, OUTPUT);
  pinMode(ledRosso, OUTPUT);
  pinMode(Buzzer, OUTPUT);
  
  SPI.begin();      // Si inizializza il canale SPI
  mfrc522.PCD_Init();   // Si inizializza la scheda NFC (MFRC522)

  Serial.begin(9600);
  Serial.println("Setup Completato...");
  Serial.println();
}

void loop() 
{
  stringaSeriale = "";
  
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
    //Serial.println("UID tag :" + UID);

    //Serial.println("Scrittura Dati su Scheda");
    /*
    WriteDataToBlock(bloccoNome, blockDataNome);
    WriteDataToBlock(bloccoCognome, blockDataCognome);
    WriteDataToBlock(bloccoID, blockDataID);
    WriteDataToBlock(bloccoAbbonamento, blockDataAbbonamento);
    WriteDataToBlock(bloccoFineAbbonamento, blockDataFineAbbonamento);
    WriteDataToBlock(bloccoCredito, blockDataCredito);
    */
    
    //Serial.println("Lettura Dati da Scheda Blocco 2");
    /*ReadDataFromBlock(bloccoNome, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");
    ReadDataFromBlock(bloccoCognome, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");
    ReadDataFromBlock(bloccoID, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");
    ReadDataFromBlock(bloccoAbbonamento, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");
    ReadDataFromBlock(bloccoFineAbbonamento, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");
    ReadDataFromBlock(bloccoCredito, readBlockData);
    stringaSeriale.concat(String((char*)readBlockData) + ";");*/

    for(int i = 0; i < numeriBlocchi; i++){
      ReadDataFromBlock(VettoreNumeriBlocchi[i], readBlockData);
      stringaSeriale.concat(String((char*)readBlockData) + ";");
    }

    Serial.println(stringaSeriale);

    /*
    WritePrintDataFromBlock(bloccoNome, readBlockData);
    WritePrintDataFromBlock(bloccoCognome, readBlockData);
    WritePrintDataFromBlock(bloccoAbbonamento, readBlockData);
    WritePrintDataFromBlock(bloccoFineAbbonamento, readBlockData);
    WritePrintDataFromBlock(bloccoCredito, readBlockData);
    */  
    
    //Serial.println();
    //Serial.println();

    /* Stampa dati badge */
    WriteAllCardData();

    /* Reset canali con Badge MiFare*/
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
  }

  while (Serial.available() == 0);
  accesso = Serial.readStringUntil('\n'); //DA CAMBIARE '\n' con ';'!
  OutputAccesso();
}
