#include "developer.h"


BOOST_CLASS_EXPORT(ShpaginDeveloper)

ShpaginDeveloper::ShpaginDeveloper() : ShpaginEmployee()
{
    main_language = L"";
	is_full_stack = false;
    current_project_name = L"";
}

QStringList ShpaginDeveloper::getColumnNames() const
{
    return ShpaginEmployee::getColumnNames() << "Основной язык программирования"
                                             << "Full Stack"
                                             << "Текущий проект";
}

QStringList ShpaginDeveloper::getData() const
{
    return ShpaginEmployee::getData() << QString::fromStdWString(main_language)
                                      << (is_full_stack ? "Да" : "Нет")
                                      << QString::fromStdWString(current_project_name);
}

