#include <SPI.h>
#include <MFRC522.h>
 
#define SS_PIN 10
#define RST_PIN 9
MFRC522 mfrc522(SS_PIN, RST_PIN);   
MFRC522::MIFARE_Key key;
MFRC522::StatusCode status;

byte writeBlockData[16] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
byte bufferLen = 18;

#define bloccoNome 4
#define bloccoCognome 5
#define bloccoID 6
#define bloccoAbbonamento 8 
#define bloccoFineAbbonamento 9 
#define bloccoCredito 10
#define numeriBlocchi 6
int VettoreNumeriBlocchi[numeriBlocchi] = {bloccoNome, bloccoCognome, bloccoID, bloccoAbbonamento, bloccoFineAbbonamento, bloccoCredito};

String stringaSeriale, nome, cognome, id, abbonamento, fineAbbonamento, credito, campo;
String VettoreDatiRicevuti[numeriBlocchi] = {nome, cognome, id, abbonamento, fineAbbonamento, credito};

bool errore = false;

#define Buzzer 7

void setup() 
{  
  SPI.begin();      // Si inizializza il canale SPI
  mfrc522.PCD_Init();   // Si inizializza la scheda NFC (MFRC522)

  Serial.begin(9600);
  pinMode(Buzzer, OUTPUT);
  
  /*Serial.println("Setup Completato...");
  Serial.println();*/
}

void loop() 
{
  /* Aspetto dei dati sulla porta seriale e li leggo */
  while(Serial.available() == 0);
  stringaSeriale = Serial.readStringUntil('#');

  /* Suddivido la stringa nei vari campi e li carico in un vettore */
  for(int i = 0; i < numeriBlocchi; i++){
    int indice = stringaSeriale.indexOf(';');
    campo = stringaSeriale.substring(0, indice);
    VettoreDatiRicevuti[i] = campo;
    stringaSeriale = stringaSeriale.substring(++indice);
  }

  /*for(int i = 0; i < numeriBlocchi; i++){
    Serial.print("Campo");
    Serial.print(i);
    Serial.print(") ");
    Serial.println(VettoreDatiRicevuti[i]);
  }*/

  /* Preparo la tessera per la lettura e la scrittura dei dati*/
  for (byte i = 0; i < 6; i++) key.keyByte[i] = 0xFF;

  /* Aspetto la presenza di una nuova scheda */
  /*Serial.println("Avvicinare tessera");*/
  while(! mfrc522.PICC_IsNewCardPresent());
  /* Seleziono una delle schede lette */
  /*Serial.println("Tessera avvicinata");*/
  while(! mfrc522.PICC_ReadCardSerial());
  /*Serial.println("Tessera selezionata");*/

  /* Nei campi della tessera NFC indicati carico le informazioni prelevate dalla Serial */
  while(errore){
    for(int i = 0; i < numeriBlocchi; i++) {
      VettoreDatiRicevuti[i].getBytes(writeBlockData,16);
      WriteDataToBlock(VettoreNumeriBlocchi[i], writeBlockData);
    }
  }
  errore = false;
  
  OutputAccesso();
}
