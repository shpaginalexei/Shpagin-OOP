// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"
#include "Company.h"
#include "Developer.h"

BOOST_CLASS_EXPORT(ShpaginDeveloper)

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

ShpaginCompany DeserializeFromFile(const std::string& filename)
{
    ShpaginCompany company;
    std::ifstream in(filename, std::ios::binary);
    boost::archive::binary_iarchive ia(in);
    ia& company;
    return company;
}

void SerializeToFile(const std::string& filename, const ShpaginCompany& company)
{
    std::ofstream out(filename, std::ios::binary);
    boost::archive::binary_oarchive oa(out);
    oa& company;
}

extern "C"
{
    __declspec(dllexport) int GetObjectsSize(char* filename)
    {
        ShpaginCompany company = DeserializeFromFile(filename);
        return (int)company.employees.size();
    }

    __declspec(dllexport) void LoadObjects(char* filename, ShpaginEmployeeOrDeveloperStruct* array)
    {
        ShpaginCompany company = DeserializeFromFile(filename);
        for (size_t i = 0; i < company.employees.size(); ++i) {
            array[i] = company.employees[i]->getStruct();
        }
    }

    __declspec(dllexport) void SaveObjects(char* filename, int size, ShpaginEmployeeOrDeveloperStruct* array)
    {
        ShpaginCompany company;
        company.employees.reserve(size);
        for (size_t i = 0; i < size; ++i) {
            if (!array[i].is_developer) {
                auto e = ShpaginEmployee(array[i]);
                auto e_ptr = std::make_shared<ShpaginEmployee>(e);
                company.employees.push_back(e_ptr);
            }
            else {
                auto d = ShpaginDeveloper(array[i]);
                auto d_ptr = std::make_shared<ShpaginDeveloper>(d);
                company.employees.push_back(d_ptr);
            }
        }
        SerializeToFile(filename, company);
    }
}