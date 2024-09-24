#pragma once
#include <iostream>
#include <string>
#include <unordered_map>


template <typename T>
T GetCorrectNumber(std::istream& in, T min, T max,
    const std::string welcome_message, const std::string error_message = "") {
    bool correct_answer = false;
    T value;
    while (!correct_answer) {

        std::cout << welcome_message;

        in >> std::ws >> value;

        if (std::cin.fail() || std::cin.peek() != '\n') {
            std::cout << "**Неверное ввод, пожалуйста, повторите\n";
        }
        else if (!(min <= value && value <= max)) {
            if (error_message == "") {
                std::cout << "**Число должно находиться в диапазоне " << min << ".." << max << ", пожалуйста, повторите\n";
            }
            else {
                std::cout << error_message;
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