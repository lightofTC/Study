#include <iostream>
#include <iomanip>
using namespace std;

//四个函数的交换
void mySwap1(int & p1, int & p2) {
	int c = p1;
	p1 = p2;
	p2 = c;
}

void mySwap2(int * p3, int * p4) {
	int c = *p3;
	*p3 = *p4;
	*p4 = c;
}

void mySwap3(int * & pA, int * & pB) {
	int *c = pA;
	pA = pB;
	pB = c;
}
void mySwap4(int **  p5, int * * p6) {

}
 void Hw3() {
	 int a(2), b(1);	
	 int * pa, *pb;
	 mySwap1(a, b);
	 cout << a << " " << b << endl;
	 a = 2; b = 1; 
	 mySwap2(&a, &b);
	 cout << a<< " " <<b << endl;
	 a = 5; b = 6;
	 int * pA = &a, *pB = &b;
	 mySwap3(pA,pB);
	 cout << a << " " <<b << endl;
	 a = 2; b = 1;
	 /*int *p51 = &a, *p52 = &b;
	 mySwap4(&p51, &p52);
	 cout << mySwap4(&p51, &p52) << endl;*/
}