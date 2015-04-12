#include "Utils.h"
#include <cmath>

double ComplexNumber::magnitude() {
	return std::sqrt(real*real + imaginary*imaginary);
}

ComplexNumber ComplexNumber::square() {
	ComplexNumber temp;
	temp.real = real*real - imaginary*imaginary;
	temp.imaginary = 2 * real*imaginary;
	return temp;
}

ComplexNumber ComplexNumber::operator+(ComplexNumber param) {
	ComplexNumber temp;
	temp.real = real + param.real;
	temp.imaginary = imaginary + param.imaginary;
	return temp;
}

