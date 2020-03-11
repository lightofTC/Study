#include <iostream>
#include <iomanip>
#include <stdlib.h>

using namespace std;

struct Stu {
	char sName[16];
	int nScore;
	struct Stu * next;
};

void DeleteLinker( Stu * pH) {
	while (NULL != pH) {
		Stu * pT = pH->next;
		delete pH;
		pH = pT;
	}
}

int Hw6() {
	struct Stu * pHeader = new struct Stu;
	pHeader -> next = NULL;
	struct Stu * pTemp = pHeader;
	for (int i = 0; i < 10; i++) {
		pTemp->next = new struct Stu;
		pTemp = pTemp->next;
		pTemp->nScore = i;
		pTemp->next = NULL;		
	}
	DeleteLinker(pTemp);
	return 0;
}