#include <iostream>
using namespace std;

void Hw1_1() {
	int a, b, c, max, min;
	cin >> a >> b >> c;
	if (a < b) {
		max = b;
		min = a;
	}
	else {
		max = a;
		min = b;
	}
	if (max < c)
		cout << c << " " << max << " " << min << endl;
	else if (min < c)
		cout << max << " " << c << " " << min << endl;
	else
		cout << max << " " << min << " " << c << endl;

}


void Hw1_2() {
	int sum = 0;
	for (int i = 1; i <= 10; i++)
		sum += i;
	cout << "1+2+3+4+5+6+7+8+9+10=" << sum << endl;
}


void Hw1_3() {
	double sum = 0;
	for (double i = 1; i <= 10; i++)
		sum += 1 / i;
	cout << "1+1/2+1/3+1/4+1/5+1/6+1/7+1/8+1/9+1/10=" << sum << endl;
}


void Hw1_4() {
	double sum = 0; int n = -1;
	double i = 1;
	for (i = 1; i <= 10; i++) {
		n *= -1;
		sum += n * (1 / i);

	}
	cout << "1-1/2+1/3-1/4+1/5-1/6+1/7-1/8+1/9-1/10=" << sum << endl;
}


void Hw1_5() {
	double sum = 0;
	double n, i, m = 1;
	double k = 1;
	for (i = 0; i <= 10; i++) {
		sum += m / k;
		n = m;
		m = k;
		k = n + k;
	}
	cout << "1+1/2+2/3+3/5+5/8+8/13+13/21+21/34+34/55+55/89=" << sum << endl;
}


void Hw1_6() {
	int i;
	int sum = 0; int m = 1; int n = 9;
	for (i = 1; i < 10; i++) {
		for (n; m <= n; m++) {
			sum = m * n;
			cout << m << "*" << n << "=" << sum << " ";
		}
		n--; m = 1;
		cout << endl;
	}
}

void Hw1_7() {
	int i, m, n, a;
	cin >> a;
	for (i = 1; i <= a; i++) {
		for (m = a - i; m >= 0; m--) {
			cout << " ";
		}
		for (n = 1; n <= (2 * i - 1); ++n) {
			cout << "*";
		}
		cout << endl;
	}
}

void Hw1_8() {
	int i, m, n, a;
	cin >> a;
	for (i = a; i > 0; i--) {
		for (m = a - i; m >= 0; m--) {
			cout << " ";
		}
		for (n = 1; n <= (2 * i - 1); ++n) {
			cout << "*";
		}
		cout << endl;
	}
}


void Hw1_9() {
	int i, m, n, k, a;
	k = 1;
	cin >> a;
	for (i = a; i > 0; i--) {
		for (m = 1; m <= 2 * k - 1; m++) {
			cout << " ";
		}
		for (n = 1; n <= (2 * i - 1); ++n) {
			cout << "*";
		}
		k++;
		cout << endl;
	}
}