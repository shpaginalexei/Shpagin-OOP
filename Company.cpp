#include "Company.h"
#include "Employee.h"
#include "Developer.h"
#include <iostream>
#include <fstream>
#include <unordered_map>
#include <filesystem>

#include <boost/serialization/shared_ptr.hpp>
#include <boost/make_shared.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <boost/archive/text_iarchive.hpp>
#include <boost/serialization/export.hpp>

BOOST_CLASS_EXPORT(ShpaginDeveloper)


void ShpaginCompany::add_employee() {
	boost::shared_ptr<ShpaginEmployee> e  = boost::make_shared<ShpaginEmployee>(ShpaginEmployee());
    e->console_input(std::cin);
    employees.push_back(e);
    changed = true;
}

void ShpaginCompany::add_developer() {
    boost::shared_ptr<ShpaginEmployee> e = boost::make_shared<ShpaginDeveloper>(ShpaginDeveloper());
    e->console_input(std::cin);
    employees.push_back(e);
    changed = true;
}

std::ostream& operator<< (std::ostream& out, const ShpaginCompany& c) {
	for (auto& e : c.employees) {
        e->console_output(std::cout);
        std::cout << std::endl;
	}
	return out;
}

std::ifstream& operator>> (std::ifstream& fin, ShpaginCompany& c) {
	size_t N;
	fin >> N;
    boost::archive::text_iarchive oa(fin);
	for (int i = 0; i < N; i++) {
        boost::shared_ptr<ShpaginEmployee> e;
        oa& e;
        c.employees.push_back(e);
	}
	return fin;
}

std::ofstream& operator<< (std::ofstream& fout, const ShpaginCompany& c) {
	fout << c.employees.size() << std::endl;
    boost::archive::text_oarchive oa(fout);
	for (auto& e : c.employees) {
        oa& e;
	}
	return fout;
}

bool ShpaginCompany::empty() const {
    return employees.size() == 0;
}

bool ShpaginCompany::saved() const {
    return !changed;
}

bool ShpaginCompany::has_saved_file() const {
    return file_name != "";
}

void ShpaginCompany::set_filename(const std::string& fn) {
    file_name = fn;
}

void ShpaginCompany::set_directory(const std::string& dir) {
    directory = dir;
}

void ShpaginCompany::clear() {
    employees.clear();
    ShpaginEmployee::reset_max_id();
    changed = false;
}

void ShpaginCompany::clear_company() {
    clear();
    std::cout << "Все данные удалены." << std::endl;
}

void ShpaginCompany::save_to_file() {
    std::ofstream file;
    file.open(directory + file_name + extention, std::ios::out);
    if (file.is_open()) {
        file << *this;
        std::cout << file_name << ": Данные " << employees.size() << " сотрудников(-а) успешно сохранены!" << std::endl;
        changed = false;
    }
    else {
        std::cout << "**Нет такого файла в каталоге\n";
        file_name = "";
    }
    file.close();
}

void ShpaginCompany::show_saves() const {
    const std::filesystem::path dir{directory};
    std::cout << "Существующие сохранения: " << std::endl;
    for (auto const& dir_entry : std::filesystem::directory_iterator{ dir }) {
        if (dir_entry.path().extension() == extention) {
            std::cout << " > " << dir_entry.path().filename().replace_extension() << std::endl;
        }
    }
    std::cout << std::endl;
}

void ShpaginCompany::load_from_file() {

    std::ifstream file;
    file.open(directory + file_name + extention, std::ios::in);
    if (file.is_open()) {
        clear();
        file >> *this;

        std::cout << file_name << ": Данные " << employees.size() << " сотрудников(-а) успешно загружены!" << std::endl;
        changed = false;
    }
    else {
        std::cout << "**Нет такого файла в каталоге\n";
        file_name = "";
    }
    file.close();
}