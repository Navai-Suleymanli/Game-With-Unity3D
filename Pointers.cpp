#include <stdio.h>
#include <iostream>
using namespace std;

void update(int* pa, int* pb) {
    // Complete this function 
    int x = *pa + *pb; // *a + *b

    // abs() gives the module of the number. 
    int y = abs(*pa - *pb);  // |*a - *b|

    // x contains their sum
    *pa = x;
    //y contains their absolute difference
    *pb = y;

}

int main() {

    //variables
    int a;
    int b;
    // a gives refference to *pa
    int* pa = &a;
    // b gives refference to *pb
    int* pb = &b;

    // Inputs
    cin >> a >> b;
    update(pa, pb);
    cout << a << "\n" << b << "\n";

    return 0;
}