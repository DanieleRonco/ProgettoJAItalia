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

void WritePrintDataFromBlock(int blockNum, byte readBlockData[])
{
  ReadDataFromBlock(blockNum, readBlockData);
  Serial.print("Lettura blocco ");
  Serial.print(blockNum);
  Serial.print(" : ");
  for (int j=0 ; j<16 ; j++) { Serial.write(readBlockData[j]); }
  Serial.println("");
}

void WriteAllCardData()
{
  for (int i=0; i<76; i++) {Serial.print("=");}
  Serial.println();
  Serial.println("DATI SCHEDA :");
  mfrc522.PICC_DumpToSerial(&(mfrc522.uid));
  for (int i=0; i<76; i++) {Serial.print("=");}
  Serial.println();
}

void OutputAccesso() {
  accesso = "OK";
  if(accesso == "OK"){
    tone(Buzzer, 4978, 500);
    digitalWrite(ledVerde, HIGH);
    digitalWrite(ledRosso, LOW);
  } else {
    tone(Buzzer, 250, 500);
    digitalWrite(ledVerde, LOW);
    digitalWrite(ledRosso, HIGH);
  }
  delay(2500); 
  digitalWrite(ledVerde, LOW);
  digitalWrite(ledRosso, LOW);
}
