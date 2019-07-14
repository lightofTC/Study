#include <iostream>
#include <iomanip>
using namespace std;

void Hw2_1() {
	int A[10] = { 56, 51, 98, 21, 48, 75, 59, 36, 81, 18 };
	for (int i = 0; i < 10; i++) {
		for (int j = 9; j > i; j--) {
			if (A[j] > A[j - 1]) {
				A[j] = A[j] + A[j - 1];
				A[j - 1] = A[j] - A[j - 1];
				A[j] = A[j] - A[j - 1];
			}			
		}
		cout << A[i] << " ";
	}
}


int Hw2_2() {
	int nWhatDay, nWhatDate;
	cin >> nWhatDay;
	cin >> nWhatDate;
	cout << "日" << " " << "一" << " " << "二" << " " << "三" << " " << "四" << " " << "五" << " " << "六" << endl;
	
	for (int a = 0; a <= 3 * nWhatDay -1; a++) {
		cout << " ";
	}
	int j = 1;
		for (int i = 1; ; i++) {
			
			int j = 1;
			for (int i = 1; ; i++) {

				for (j; nWhatDay < 7; j++) {
					if (j < 10) {
						cout << " " << j << " ";
						nWhatDay++;
					}
					else if (j <= nWhatDate) {
						cout << j << " ";
						nWhatDay++;
					}
					else return 0;
				}

				nWhatDay = 0;
				cout << endl;
			}
				}	
			nWhatDay = 0;
			cout << endl;
		}
	



void Hw2_3() {
	int  Months[12] = { 31,29,31,30,31,30,31,31,30,31,30,31 };
	int Year;
	int b = 0;
	cin >> Year;
	if (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0) {
		Months[1] = 28;
	}
		

	
	int month;
	for (month=0; month < 12; month++) {
		cout << "日" << " " << "一" << " " << "二" << " " << "三" << " " << "四" << " " << "五" << " " << "六" << endl;
		int nWhatDay = 1;
		for (int a = 0; a <= 3 * nWhatDay - 1; a++) {
			cout << " ";
		}
		
		int j = 1;
		for (j; nWhatDay < 7; j++) {
			if (j < 10) {
				cout << " " << j << " ";
				nWhatDay++;
			}
			else if (j <= Months[month]) {
				cout << j << " ";
				nWhatDay++;
			}
			nWhatDay = 0;
			cout << endl;
		}
	}
}