/* Funzione di scrittura dati su scheda NFC in uno specifico blocco dati */
void WriteDataToBlock(int blockNum, byte blockData[]) 
{
  status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, blockNum, &key, &(mfrc522.uid));
  if (status != MFRC522::STATUS_OK)
  {
    Serial.print("ERRORE in AUTENTICAZIONE per SCRITTURA: ");
    Serial.println(mfrc522.GetStatusCodeName(status));
    return;
  }
  
  status = mfrc522.MIFARE_Write(blockNum, blockData, 16);
  if (status != MFRC522::STATUS_OK)
  {
    Serial.print("ERRORE in SCRITTURA: ");
    Serial.println(mfrc522.GetStatusCodeName(status));
    return;
  }  
}


/* Funzione di lettura dati da scheda NFC di uno specifico blocco dati */
void ReadDataFromBlock(int blockNum, byte readBlockData[]) 
{
  byte status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, blockNum, &key, &(mfrc522.uid));
  
  if (status != MFRC522::STATUS_OK)
  {
     Serial.print("ERRORE in AUTENTICAZIONE per LETTURA: ");
     Serial.println(mfrc522.GetStatusCodeName(status));
     return;
  }
  
  status = mfrc522.MIFARE_Read(blockNum, readBlockData, &bufferLen);
  if (status != MFRC522::STATUS_OK)
  {
    Serial.print("ERRORE in LETTURA: ");
    Serial.println(mfrc522.GetStatusCodeName(status));
    return;
  }  
}


/* Funzione per leggere e stampare il contenuto di un blocco dati */
void WritePrintDataFromBlock(int blockNum, byte readBlockData[])
{
  ReadDataFromBlock(blockNum, readBlockData);
  Serial.print("Lettura blocco ");
  Serial.print(blockNum);
  Serial.print(" : ");
  for (int j=0 ; j<16 ; j++) { Serial.write(readBlockData[j]); }
  Serial.println("");
}


/* Funzione per stampare le info della carta e il suo contenuto */
void WriteAllCardData()
{
  for (int i=0; i<76; i++) {Serial.print("=");}
  Serial.println();
  Serial.println("DATI SCHEDA :");
  mfrc522.PICC_DumpToSerial(&(mfrc522.uid));  /* funzione della libreria per stampare tutte le informazioni della scheda dato l'UID*/
  for (int i=0; i<76; i++) {Serial.print("=");}
  Serial.println();
}

void OutputAccesso() {  
  tone(Buzzer, 3000, 500);
}
