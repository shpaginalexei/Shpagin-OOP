#pragma once
#include "Company.h"
#include <string>


void Print(const std::string[], const int);
void BackToMenu();

void MainMenu(ShpaginCompany&);

bool CheckBeforeSave(ShpaginCompany&);
void CheckBeforeExit(ShpaginCompany&);
void CheckBeforeLoad(ShpaginCompany&);
