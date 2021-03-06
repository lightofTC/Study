// DataStructureExperiment3.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
using namespace std;

#define M 4
#define N 4
#define MaxSize 100

int mg[M + 2][N + 2] = {
	{1,1,1,1,1,1},{1,0,0,0,1,1},{1,0,1,0,0,1},{1,0,0,0,1,1},{1,1,0,0,0,1},{1,1,1,1,1,1}
};

//struct {
//	int i, j;
//	int di;
//}St[MaxSize],Path[MaxSize];
//
//int top = -1; 
//int minlen = MaxSize;
//int count1 = 1;
//
//void dispapath() {
//	int k;
//	cout<<count1++;
//	for (k = 0; k <= top; k++)
//		printf("(%d,%d)", St[k].i, St[k].j);
//	cout << endl;
//	if (top + 1 < minlen) {
//		for (k = 0; k <= top; k++)
//			Path[k] = St[k];
//		minlen = top + 1;
//	}
//}
//void dispminpath() {
//	cout << "最短路径如下：" << endl;
//	printf("长度：%d\n", minlen);
//	cout<<"路径：";
//	for (int k = 0; k < minlen; k++)
//		printf("(%d,%d)",Path[k].i, Path[k].j);
//	cout << endl;
//}
//
//void mgpath(int xi, int yi, int xe, int ye) {     //栈方法
//	int i, j, i1, j1, di;
//	bool find;
//	top++;
//	St[top].i = xi;
//	St[top].j = yi;
//	St[top].di = -1; mg[xi][yi] = -1;
//	while(top > -1) {
//		i = St[top].i; j = St[top].j;
//		di = St[top].di;
//		if (i == xe && j == ye) {
//			dispapath();
//			mg[i][j] = 0;
//			top--;
//			i = St[top].i; j = St[top].j;
//			di = St[top].di;
//		}
//		find = false;
//		while (di < 4 && !find) {
//			di++;
//			switch (di) {
//			case 0:
//				i1 = i - 1; j1 = j; break;
//			case 1:
//				i1 = i; j1 = j + 1; break;
//			case 2:
//				i1 = i + 1; j1 = j; break;
//			case 3:
//				i1 = i; j1 = j - 1; break;
//			}
//			if (mg[i1][j1] == 0)
//				find = true;
//		}
//		if (find) {
//			St[top].di = di;
//			top++; St[top].i = i1; St[top].j = j1;
//			St[top].di = -1;
//			mg[i1][j1] = -1;
//		}
//		else {
//			mg[i][j] = 0;
//			top--;
//		}
//	}
//	dispminpath();
//}


typedef struct
{
	int i, j;           
	int pre;            
} Box;
typedef struct {
	Box data[MaxSize];
	int front, rear;
}QuType;
void InitQueue(QuType *&q) {
	q = (QuType*)malloc(sizeof(QuType));
	q->front = q->rear = -1;
}
void DestroyQueue(QuType*&q) {
	free(q);
}
bool QueueEmpty(QuType * q) {
	return (q->front==q->rear);
}
bool enQueue(QuType*&q, Box e) {
	if (q->rear == MaxSize - 1)
		return false;
	q->rear++;
	q->data[q->rear] = e;
	return true;
}
bool deQueue(QuType *&q, Box e) {
	if (q->front == q->rear)
		return false;
	q->rear++;
	q->data[q->rear] = e;
	return true;
}
void print(QuType *qu, int front) {
	int k = front, j, ns = 0;
	printf("\n");
	do {
		j = k;
		k = qu->data[k].pre;
		qu->data[j].pre = -1;
	} while (k != 0);
	printf("一条迷宫的路径如下:\n");
	k = 0;
	while (k <=front)
	{
		if (qu->data[k].pre == -1) {
			ns++;
			printf("\t(%d,%d)", qu->data[k].i, qu->data[k].j);
			if (ns % 5 == 0)
				printf("\n");
		}
		k++;
	}
	printf("\n");
}

bool mgpath1(int xi, int yi, int xe, int ye) {
	Box e;
	int i, j, i1, j1,di;
	QuType *qu;
	InitQueue(qu);
	e.i = xi; e.j = yi; e.pre = -1;
	enQueue(qu, e);
	mg[xi][yi] = -1;
	while (!QueueEmpty(qu)) {
		deQueue(qu, e);
		i = e.i; j = e.j;
		if (i == xe && j == ye) {
			print(qu, qu->front);
			DestroyQueue(qu);
			return true;
		}
		for (di = 0; di < 4; di++) {
			switch (di) {
			case 0:
				i1 = i - 1; j1 = j; break;
			case2:
				i1 = i; j = j + 1; break;
			case 2:
				i1 = i + 1; j1 = j; break;
			case 3:
				i1 = i; j1 = j - 1; break;
			}
			if (mg[i1][j1] == 0) {
				e.i = i1; e.j = j1;
				e.pre = qu->front;
				enQueue(qu, e);
				mg[i1][j1] = -1;
			}
		}
	}
	DestroyQueue(qu);
	return false;
}



int main()
{
	/*cout << "用栈：" << endl;
	cout << "迷宫所有路径如下：" << endl;
	mgpath(1, 1, M, N);*/
	cout << endl << "用队列：" << endl;
	if (mgpath1(1, 1, M, N))
		cout << "迷宫无解";
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
