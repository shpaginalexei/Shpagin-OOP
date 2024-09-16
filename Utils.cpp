#include "Utils.h"


std::string enumToString(const Departament& dep) {
    return DepartamentToString[dep];
}

std::string enumToString() {
    std::string result;
    bool first = true;

    for (const auto& [key, value] : DepartamentToString) {
        if (!first) {
            result += ", ";
        }
        result += std::to_string(key) + " - " + value;
        first = false;
    }

    return result;
}