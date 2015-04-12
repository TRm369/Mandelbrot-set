#pragma once
#ifndef utils
#define utils

class ComplexNumber{
public:
	double real;
	double imaginary;
	//ComplexNumber(double r, double i);
	double magnitude();
	ComplexNumber square();
	ComplexNumber operator+(ComplexNumber param);
};
#endif

