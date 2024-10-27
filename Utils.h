#pragma once
#include "pch.h"


template <typename T>
T GetCorrectNumber(std::istream& in, T min, T max,
    const std::wstring welcome_message, const std::wstring error_message = L"") {
    bool correct_answer = false;
    T value;
    while (!correct_answer) {

        std::wcout << welcome_message;

        in >> std::ws >> value;

        if (std::cin.fail() || std::cin.peek() != '\n') {
            std::wcout << L"**Неверное ввод, пожалуйста, повторите\n";
        }
        else if (!(min <= value && value <= max)) {
            if (error_message == L"") {
                std::wcout << L"**Число должно находиться в диапазоне " << min << L".." << max << L", пожалуйста, повторите\n";
            }
            else {
                std::wcout << error_message;
            }
        }
        else {
            correct_answer = true;
        }
        in.clear();
        in.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
    return value;
}