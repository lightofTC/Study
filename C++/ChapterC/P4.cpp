#include<iostream>
using namespace std;
extern void p1dispG();
extern void p2dispG();
extern void p2dispg();

int G = 0, g = 0;
int P4_1(){
	p1dispG();
    p2dispG();
    p2dispg();
	cout << "in p G = " << G << endl;
	cout << "in p g = " << g << endl;
	return 0;
	}



void fun() {
	static int n = 0;
	int m = 0;
	n++;
	m++;
	cout << "m = " << m << ", n = " << n << endl;
}
int P4_2() {
	for (int i = 0; i < 4; i++)
		fun();
	return 0;
}


int k = 300;
const int i = 200;
#define n 5
const int j = 200;
void fun1(int i = 1, int j = 2.) {
	const int k = 3;
	static int l = 0;
	int m;
	char * p = (char *)"abcde";
	char *q = new char[n + 1];
	for (m = 0; m < n; m++)
		q[m] = 'A' + m;
	q[m] = '\0';
	cout << "���������ĵ�ַ��" << endl;
	cout << "\t" << "&i = " << &i <<"\t" << "&j = " << &j <<endl;
	cout << "�ֲ������ĵ�ַ��" << endl;
	cout << "\t" << "& k= " << &k << "\t" << "&m = " << &m << "\t" << "&p  = " << &p << "\t" << "&q = " << &q << endl; 
	cout << "��̬�ֲ������ĵ�ַ��" << endl;
	cout << "\t" << "&l = " << &l << endl;
	cout << "�ַ��������ĵ�ַ��" << endl;
	cout << "\t" << "p���ĵ�ַ = " << (void *)p << endl;
	cout << "�ѵĵ�ַ��" << endl;
	cout << "\t(void *)q = " << (void *)q << endl;
	cout << "\tq�� = " << q << endl;
	delete[] q;
	cout << "\tdelete�󣬣�void *��q = " << (void *)q << endl;
	cout << "\tdelete��qָ��ĵ�Ԫ������ = " << (void *)q << endl;
}
int P4_3() {
L1:fun1();
L2:cout << "ȫ�ֱ����ĵ�ַ��" << endl;
	cout << "\t&i = " << &i << "\t" << "&j = " << &j << "\t" << "&k = " << &k << endl;
	//cout << "&fun1 = " << &fun1 << "\t" << "&P4_3 = " << &P4_3 << endl; //VC
	cout << "\t&fun1 = " << (void *)fun1 << "\t" << "&P4_3 = " << (void *)P4_3 << endl;
	return 0;
}


//int i = 100, j = 200;
//int fun2(int i=2) {
//	cout << "L2:i = " << i << endl;
//	{
//		int i = 3;
//		cout << "L3: i = " << i << endl;
//		for (int i = 4; i < 5; cout << "L6:i = " << i << endl, i++) {
//			cout << "L4: i = " << i << endl;
//			int i = 5;
//			j++;
//			cout << "L5: i = " << i << endl;
//		}
//	}
//}
//int P4_4() {
//	fun2();
//	return 0;
//}



#include "mymath.h"
int P4_5() {
	cout << max1(5, 6) << endl;
	return 0;
}


#include "TsingHua.h"
int P4_6() {
	TsingHua::ShowName();
	return 0;

}





using std::cout;
using std::endl;
int P4_7() {
	using TsingHua::ShowName;
	ShowName();
	return 0;
}








