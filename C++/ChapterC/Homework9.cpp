#include <iostream>
#include <iomanip>
#include <stdlib.h>
#include<fstream>
using namespace std;

struct CStu {
	char sNum[14];
	char sName[14];
	char sTemp1;
	char sTemp2;
	int nScores[6];
	struct CStu * next;
};

CStu * CreateLinkerFromBinaryFile(const char * pBinaryFileName) {
	ifstream in;
	in.open(pBinaryFileName, ios::binary | ios::in);
	if (!in.is_open()) return NULL;
	int nCount = 0;
	in.read((char *)&nCount, sizeof(int));
	CStu *pH = new CStu();
	pH = pH->next;
	pH->next = NULL;
	CStu * pT = pH;
	for (int i = 0; i < nCount; i++) {
		pT->next = new CStu();
		pT = pT->next;
		pT->next = NULL;
		short nLen = 0;
		in.read((char *)&nLen, sizeof(nLen));
		in.read(pT -> sNum, nLen);
		pT->sNum[nLen] = '\0';

		in.read((char *)&nLen, sizeof(nLen));
		in.read(pT -> sName, nLen);
		pT->sName[nLen] = '\0';

		float fScore;
		for (int j = 0; j < 5; j++) {
			in.read((char *)&fScore, sizeof(float));
			pT->nScores[j] = (int)fScore;
		}
		in.read((char *)&fScore, sizeof(float));
		in.read((char *)&fScore, sizeof(float));
	}
	return pH;

}

int Hw9() {
	CreateLinkerFromBinaryFile("E:\C++\123456.txt");
}