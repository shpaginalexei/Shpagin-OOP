#include "Company.h"
#include "Employee.h"
#include "Developer.h"


void ShpaginCompany::add_employee()
{
	std::shared_ptr<ShpaginEmployee> e  = std::make_shared<ShpaginEmployee>(ShpaginEmployee());
    e->console_input();
    employees.push_back(e);
    changed = true;
}

void ShpaginCompany::add_developer()
{
    std::shared_ptr<ShpaginEmployee> e = std::make_shared<ShpaginDeveloper>(ShpaginDeveloper());
    e->console_input();
    employees.push_back(e);
    changed = true;
}

std::wostream& operator<< (std::wostream& out, const ShpaginCompany& c)
{
	for (auto& e : c.employees) {
        e->console_output();
        std::wcout << L"\n";
	}
	return out;
}

bool ShpaginCompany::empty() const
{
    return employees.size() == 0;
}

bool ShpaginCompany::saved() const
{
    return !changed;
}

bool ShpaginCompany::has_saved_file() const
{
    return file_name != L"";
}

void ShpaginCompany::set_filename(const std::wstring& fn)
{
    file_name = fn;
}

void ShpaginCompany::set_directory(const std::wstring& dir)
{
    directory = dir;
}

void ShpaginCompany::clear()
{
    employees.clear();
    ShpaginEmployee::reset_max_id();
    changed = false;
}

void ShpaginCompany::clear_company()
{
    clear();
    std::wcout << L"Все данные удалены." << std::endl;
}

void ShpaginCompany::save_to_file()
{
    std::ofstream file(directory + file_name + extention, std::ios::binary);
    if (file.is_open()) {

        boost::archive::binary_oarchive oa(file);
        oa& *this;

        std::wcout << file_name << L": Данные " << employees.size() << L" сотрудников(-а) успешно сохранены!" << std::endl;
        changed = false;
    }
    else {
        std::wcout << L"**Нет такого файла в каталоге\n";
        file_name = L"";
    }
    file.close();
}

void ShpaginCompany::show_saves() const {
    const std::filesystem::path dir{directory};
    std::wcout << L"Существующие сохранения: " << std::endl;
    for (auto const& dir_entry : std::filesystem::directory_iterator{ dir }) {
        if (dir_entry.path().extension() == extention) {
            std::wcout << L" > " << dir_entry.path().filename().replace_extension() << std::endl;
        }
    }
    std::cout << std::endl;
}

void ShpaginCompany::load_from_file() {

    std::ifstream file(directory + file_name + extention, std::ios::binary);
    if (file.is_open()) {
        clear();

        boost::archive::binary_iarchive ia(file);
        ia& *this;
        
        std::wcout << file_name << L": Данные " << employees.size() << L" сотрудников(-а) успешно загружены!" << std::endl;
        changed = false;
    }
    else {
        std::wcout << L"**Нет такого файла в каталоге\n";
        file_name = L"";
    }
    file.close();
}