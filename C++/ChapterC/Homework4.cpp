#include <iostream>
#include <iomanip>
#include <stdlib.h>

using namespace std;


//字符串长度
int MyStrLen(const char *pStr) {
	const char *Header = pStr;
	while ('\0' != *pStr) { 
		pStr++;		
	}
	return pStr - Header;
}

//字符串比较
int MyStrCompare(const char *pStr1_1, const char *pStr1_2) {
	int i(0);
	while (*(pStr1_1+i) == *(pStr1_2+i)) {
		i++;
	}
	if (*(pStr1_1 + i) > *(pStr1_2 + i))
		return 1;	
	 else if (*(pStr1_1 + i) < *(pStr1_2 + i))
	 return -1;	 
	 else return 0;
}

//字符串连接
char * MyStrCat(char * pStr1, const char * pStr2) {
	int i = 0; 
	while ('\0' != *(pStr1+i) ){
		i++;
	}
	int j = 0;
	while ('\0' != *(pStr2+j)) {
		*(pStr1 + i) = *(pStr2 + j);
			i++;
			j++;
	}
	*(pStr1 + i) = '\0';
	return pStr1;
}

//字符串的拷贝
char * MyStrCopy(char * pStr3,const char * pStr4) {
	int i = 0; 
	while ('\0' != *(pStr4+i)) {
		*(pStr3 + i) = *(pStr4 +i);
		i++;
	}
		if ('\0' != *(pStr3+i)) {
			*(pStr3 + i) = '\0';	
	}
	return pStr3;
}


//字符串的反转
char * MyStrReverse(char * pStr5, char * pStr6, int t) {
	int i(0);
	for (t; t >= 0; t--) {
		*(pStr5 + i) = *(pStr6 + t - 1);
		i++;
	}
	return pStr5;
}

//去掉数字
char * EraseDigital(char * pStr7) {
	int i = 0; int j = 0;
	while ('\0' != *(pStr7 + j) ){
		if (*(pStr7 + j) < 10 ) {
			 j++;
		}
		else {
			*(pStr7+i) = *(pStr7 + j);
			i++; j++;
		}
		*(pStr7 + i) = '\0';
	}

	return pStr7;
}

void Hw4() {
	char num1[1000] = {0};
	char num2[1000] = {0};
	cin >> num1;
	cin >> num2;
	 MyStrLen(num1);
	cout << MyStrLen(num1) << endl;
	MyStrCompare(num1, num2);
	cout << MyStrCompare(num1, num2) << endl;
	MyStrCat(num1, num2);
	cout << num1<< endl;
	cout << MyStrCopy(num1, num2)<< endl;	
	MyStrReverse(num1,num2, MyStrLen(num2));	
	/*cout << EraseDigital(num1)<< endl;*/
}