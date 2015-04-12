#include <iostream>
#include "utils.h"
#include <fstream>
#include <cmath>
#include <time.h> 

ComplexNumber cplx;
int ending;
int maxIteration;
double precision;
double real=-2;
double imaginary=-1;
int x;
int y;
ComplexNumber num;


char testNumber(ComplexNumber number){
	ComplexNumber Z;
	Z.real = 0;
	Z.imaginary = 0;
	for (int iteration = 1; iteration< maxIteration + 1; iteration++) {
		Z = Z.square() + number;
		if (Z.magnitude() > 2.0) {
			return iteration;
		}
	}
	return 0;
}

int main() {
	using namespace std;
	filebuf fb;
	fb.open("mandelbrotset.dat", std::ios::out | std::ios::binary);
	ostream file(&fb);
	clock_t t;

	cout << "Max iteration:" << endl;
	cin >> maxIteration;
	cout << "Precision:" << endl;
	cin >> precision;

	x = 3 / precision;
	y = 2 / precision;

	char *data = new char[x];

	data[0] = floor(x / (256 * 256 * 256));
	x = x % (256 * 256 * 256);
	data[1] = floor(x / (256 * 256));
	x = x % (256 * 256);
	data[2] = floor(x / 256);
	x = x % 256;
	data[3] = x;

	data[4] = floor(y / (256 * 256 * 256));
	y = y % (256 * 256 * 256);
	data[5] = floor(y / (256 * 256));
	y = y % (256 * 256);
	data[6] = floor(y / 256);
	y = y % 256;
	data[7] = y;

	file.write(data, 8);
	
	x = 3 / precision;
	y = 2 / precision;

	t = clock();

	for (int currentY = 0; currentY < y; currentY++) {
		for (int currentX = 0; currentX < x; currentX++) {
			
			num.real = precision*currentX-2;
			num.imaginary = 1-precision*currentY;
			data[currentX] = testNumber(num);
		}
		file.write(data,x);
	}
	file.flush();
	t = clock() - t;
	float speed = ((float)t) / CLOCKS_PER_SEC;
	cout << "Execution time: " << speed << " s"<< endl;
	cout << "Calculation speed: " << (x*y / speed) << " p/s" << endl;
	cout << "Done! Press enter to exit";
	cin >> ending;
	return 0;
}