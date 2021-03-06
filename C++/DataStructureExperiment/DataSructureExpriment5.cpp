// DataSructureExpriment5.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <malloc.h>
using namespace std;

#define MaxSize 100

typedef struct node {
	char data;
	struct node*lchild;
	struct node*rchild;
}BTNode;

void CreateBTree(BTNode *&b, char *str) {
	BTNode *St[MaxSize], *p=NULL;
	int top = -1, k, j = 0;
	char ch;
	b = NULL;
	ch = str[j];
	while (ch != '\0') {
		switch (ch)
		{
		case '(':top++; St[top] = p; k = 1;break;
		case ')':top--; break;
		case ',':k = 2; break;
		default:p = (BTNode *)malloc(sizeof(BTNode));
			p->data = ch;
			p->lchild = p->rchild = NULL;
			if (b == NULL)
				b = p;
			else {
				switch (k) {
				case 1:St[top]->lchild = p; break;
				case 2:St[top]->rchild = p; break;
				}
			}
		}
		j++;
		ch = str[j];
	}
}


void DestroyBTree(BTNode *& b) {
	if (b != NULL) {
		DestroyBTree(b->lchild);
		DestroyBTree(b->rchild);
		free(b);
	}
}

void DispBTree(BTNode*b) {
	if (b != NULL) {
		cout << b->data;
		if (b->lchild != NULL || b->rchild != NULL) {
			cout << "(";
			DispBTree(b->lchild);
			if (b->rchild != NULL)
				cout << ",";
			DispBTree(b->rchild);
			cout << ")";
		}
	}
}


void PreOrder(BTNode*b) {
	if (b != NULL) {
		cout << b->data;
		PreOrder(b->lchild);
		PreOrder(b->rchild);
	}
}


//非递归算法

void PreOrder1(BTNode *b) {
	BTNode*p,*St[MaxSize];
	int top = -1;
	if (b != NULL) {
		top++;
		St[top] = b;
		while (top>-1) {
			p = St[top];
			top--;
			cout << p->data;
			if (p->rchild != NULL) {
				top++;
				St[top] = p->rchild;
			}
			if (p->lchild != NULL) {
				top++;
				St[top] = p->lchild;
			}
		}
		cout << "\n";
	}
}


int main()
{
	BTNode *b;
	CreateBTree(b, (char*)"A(B(D,E(H(J,K(L,M(,N))))),C(F,G(,I)))");
	cout << "二叉树b:";
	DispBTree(b); 
	cout << endl << "先序遍历递归算法：" << endl;
	PreOrder(b);
	cout << endl << "先序遍历非递归算法：" << endl;
	PreOrder1(b);

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
