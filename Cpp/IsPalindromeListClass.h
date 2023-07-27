#pragma once
#include <stack>

using namespace std;

struct ListNode {
    int val;
    ListNode *next;

    ListNode() : val(0), next(nullptr) {}

    ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}

    ~ListNode(){
        if(next != nullptr){
            delete next;
            next = nullptr;
        }
    }
};

class IsPalindromeListClass {
public:
    bool isPalindrome(ListNode* head) {
        byte m[100000];
        auto c = head;
        int n = 0;

        while(c){
            m[n++] = static_cast<byte>(c->val);
            c = c->next;
        }

        for(int i = 0; i < n/2; i++){
            if(m[i] != m[n-i-1]) return false;
        }

        return true;
    }

    bool isPalindrome1(ListNode* head) {
        auto n = 0;
        auto c = head;

        while(c){
            c = c->next;
            n++;
        }

        stack<int> st{};

        c = head;
        for(int i = 0; i < n/2; i++){
          st.push(c->val);
          c = c-> next;
        }

        if(n % 2 == 1) c = c->next;

        while(c){
            if(st.top() != c->val) return false;
            st.pop();
            c = c-> next;
        }

        return true;
    }
};