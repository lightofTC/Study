// DataStructureExperimen4.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
using namespace std;

#define N 50
#define M 2*N-1
typedef struct {
	char data[5];
	int weight;
	int parent,lchild, rchild;
}HTNode;


void CreateHT(HTNode ht[], int n0) {
	int i, k, lnode, rnode;
	int min1, min2;
	for (int i = 0; i < 2 * n0 - 1; i++)
		ht[i].parent = ht[i].lchild = ht[i].rchild = -1;
	for (i = n0; i <= 2 * n0 - 2; i++) {
		min1 = min2 = 32767;
		lnode = rnode = -1;
		for(k=0;k<=i-1;k++)
			if (ht[k].parent == -1) {
				if (ht[k].weight < min1) {
					min2 = min1;
					rnode = lnode;
					min1 = ht[k].weight;
					lnode = k;
				}
				else if (ht[k].weight < min2) {
					min2 = ht[k].weight;
					rnode = k;
				}
			}
		ht[i].weight = ht[lnode].weight + ht[rnode].weight;
		ht[i].lchild = lnode;
		ht[i].rchild = rnode;
		ht[lnode].parent = i;
		ht[rnode].parent = i;
	}
}

typedef struct {
	char cd[N];
	int start;
}HCode;

void CreateHCode(HTNode ht[], HCode hcd[], int n0) {
	int i, f, c;
	HCode hc;
	for (i = 0; i < n0; i++) {
		hc.start = n0;
		c = i;
		f = ht[i].parent;
		while (f != -1) {
			if (ht[f].lchild == c)
				hc.cd[hc.start--] = '0';
			else
				hc.cd[hc.start--] = '1';
			c = f;
			f = ht[f].parent;
		}
		hc.start++;
		hcd[i]=hc;
	}
}void DispHCode(HTNode ht[], HCode hcd[], int n) {
	int i, k; int sum = 0, m = 0, j;
	cout << "输出哈夫曼树：" << endl;
	for (int i = 0; i < n; i++) {
		j = 0;
		printf("  %s:\t", ht[i].data);
		for (k = hcd[i].start; k <= n; k++) {
			printf("%c", hcd[i].cd[k]);
			j++;
		}
		m += ht[i].weight;
		sum += ht[i].weight*j;
	}
	cout << "\n平均长度=" << 1.0*sum / m;
}

#pragma warning(disable:4996)
int main()
{
	int n = 6, i;
	char *str[] = { (char*)"A",(char*)"B",(char*)"C",(char*)"D",(char*)"E",(char*)"F" };
	int array[7] = { 12,1,23,35,48,78 };
	HTNode ht[M];
	HCode hcd[N];
	for (i = 0; i < n; i++) {
		strcpy(ht[i].data, str[i]);
		ht[i].weight = array[i];
	}
	CreateHT(ht, n);
	CreateHCode(ht,hcd,n);
	DispHCode(ht, hcd, n);
	return 1;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
