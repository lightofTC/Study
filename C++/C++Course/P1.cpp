// ChapterC.cpp: 定义控制台应用程序的入口点。
//

#include <iostream>
#include <iomanip>
using namespace std;


void P1_1() {    //例1-1
	cout << "Hello C++!" << endl;
  }

void P1_2() {//例2-2
	float num1, num2, num3;
	cout << "Please input three numbers:";
	cin >> num1 >> num2 >> num3;
	cout << "The average of " << num1 << "," << num2 << "and" << num3;
	cout << "is:" << (num1 + num2 + num3) / 3 << endl;
}

void P1_3() {//例1-3
	float num13, num23, num33;
	cout << "Please input three numbers:";
	cin >> num13 >> num23 >> num33;
	cout << setw(8) << setprecision(12);
	cout << "The average of " << num13 << "," << num23 << "and" << num33;
	cout << "is:" << setw(20) << (num13 + num23 + num33) / 3 << endl;
}

