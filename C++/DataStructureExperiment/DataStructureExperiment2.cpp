// DataStructureExperiment2.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
using namespace std;

typedef char ElemType;

typedef struct linknode {
	ElemType data;
	struct linknode *next;
}LinkStNode;

void InitStack(LinkStNode *& L) {
	L = (LinkStNode *)malloc(sizeof(LinkStNode));
	L->next = NULL;
}


void DestroyStack(LinkStNode *& L) {
	LinkStNode * pre=L, *p = L->next;
	while (p != NULL) {
		free(pre);
	    pre = p;
		p = pre->next;
	}
	free(pre);
}
bool StackEmpty(LinkStNode *L) {
	return (L->next == NULL);
}

void Push(LinkStNode *& L, ElemType e) {
	LinkStNode*p;
	p = (LinkStNode *)malloc(sizeof(LinkStNode));
	p->data = e;
	p->next = L->next;
	L->next = p;
}

bool Pull(LinkStNode *& L, ElemType &e) {
	LinkStNode *p;
	if (L->next == NULL)
		return false;
	p = L->next;
	e = p->data;
	L->next = p->next;
	free(p);
	return true;
}
bool GetTop(LinkStNode*L, ElemType &e) {
	if (L->next == NULL)
		return false;
	e = L->next->data;
	return true;
}



bool Match(char exp[], int n) {
	bool match = true;
	int i = 0; char e;
	LinkStNode *st;
	InitStack(st);
	while (i < n && match) {
		if (exp[i] == '(')
			Push(st, exp[i]);
		else if (exp[i] == ')') {
			if (GetTop(st, e) == true) {
				if (e != '(')
					match = false;
				else
					Pull(st, e);
			}
			else match = false;
		}
		i++;
	}
	if (!StackEmpty(st))
		match = false;
	DestroyStack(st);
	return match;
}

void print(bool a) {
	if (a == true)
		cout << "左右括号匹配！";
	else
		cout << "左右括号不匹配！";
}


int main()
{
	char a[10] = "h(dhdy(k)";
	cout << "数组为：";
	for (int i = 0; i < 10; i++) {
		cout << a[i] << " ";
	}
	cout << endl;
	print(Match(a, 10));
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
