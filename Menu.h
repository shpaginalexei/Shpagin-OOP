﻿#pragma once
#include "pch.h"
#include "Company.h"


void Print(const std::wstring[], const int);
void BackToMenu();

void MainMenu(ShpaginCompany&);

bool CheckBeforeSave(ShpaginCompany&);
void CheckBeforeExit(ShpaginCompany&);
void CheckBeforeLoad(ShpaginCompany&);
