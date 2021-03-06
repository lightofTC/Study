// DataStructureExperiment.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include<malloc.h>

using namespace std;

typedef struct LNode {
	int data;
	struct LNode*next;
}LinkNode;

void CreateListF(LinkNode *& L, int a[], int n) {      //头插法建立链表
	LinkNode *s;
	L = (LinkNode *)malloc(sizeof(LinkNode));
	L->next = NULL;
	for (int i = 0; i < n; i++) {
		s = (LinkNode*)malloc(sizeof(LinkNode));
		s->data = a[i];
		s->next = L->next;
		L->next = s;
	}
}
void InitList(LinkNode *&L) {
	L = (LinkNode*)malloc(sizeof(LinkNode));
	L->next = NULL;
}

void DestroyList(LinkNode *&L) {
	LinkNode*pre =L, *p = pre->next;
	while (p != NULL) {
		free(pre);
		pre = p;
		p = p->next;
	}
	free(pre);
}

bool ListEmpty(LinkNode*L) {
	return(L->next == NULL);
}

void InsertSort(LinkNode R[], int n) {
	int i, j;
	LinkNode tmp;
	for (i = 1; i < n; i++) {
		if (R[i].data < R[i - 1].data) {
			tmp = R[i];
			j = i - 1;
			do {
				R[j + 1] = R[j];
				j--;
			} while (j >= 0 && R[j].data > tmp.data);
			R[j + 1] = tmp;
		}
	}
}

void DispList(LinkNode *L) {
	LinkNode *p= L->next;
	while (p != NULL) {
		cout << p->data<<" ";
		p = p->next;
	}
	cout << "\n";
}

void Sort(LinkNode *&L) {         //单链表递增排序
	LinkNode*p, *pre, *q;
	p = L->next->next;
	L->next->next = NULL;
	while (p != NULL) {
		q = p->next;
		pre = L;
		while (pre->next != NULL && pre->next->data < p->data) {
			pre = pre->next;
		}
		p->next = pre->next;
		pre->next = p;
		p = q;
	}
}

void Union(LinkNode*ha, LinkNode*hb, LinkNode*&hc) {      //两个有序集合的并
	LinkNode*pa = ha->next, *pb = hb->next, *s, *tc;
	hc = (LinkNode*)malloc(sizeof(LinkNode));
	tc = hc;
	while (pa != NULL && pb != NULL) {
		if (pa->data < pb->data) {
			s = (LinkNode *)malloc(sizeof(LinkNode));
			s->data = pa->data;
			tc->next = s; tc = s;
			pa = pa->next;
		}
		else if (pa->data > pb->data) {
			s = (LinkNode *)malloc(sizeof(LinkNode));
			s->data = pb->data;
			tc->next = s; tc = s;
			pb = pb->next;
		}
		else {
			s = (LinkNode*)malloc(sizeof(LinkNode));
			s->data = pa->data;
			tc->next = s; tc = s;
			pa = pa->next;
			pb = pb->next;
		}
	}
	if (pb != NULL)pa = pb;
	while (pa != NULL) {
		s = (LinkNode*)malloc(sizeof(LinkNode));
		s->data = pa->data;
		tc->next = s; tc = s;
		pa = pa->next;
	}
	tc->next = NULL;
}

int main()
{
	int a[6] = { 10, 64, 27, 6, 41, 38 };
	int b[6] = { 90,60,25,46,39,48 };
	LinkNode *ha, *hb,*hc;
	CreateListF(ha, a, 6);
	CreateListF(hb, b, 6);
	cout << "原数组A:";DispList(ha);
	cout << "原数组B:"; DispList(hb);
	Sort(ha); Sort(hb);
	cout << "有序数组A:"; DispList(ha);
	cout << "有序数组A:"; DispList(hb);
	Union(ha, hb, hc);
	cout << "合并后的数组："; DispList(hc);
	DestroyList(ha);
	DestroyList(hb);
	DestroyList(hc);

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
