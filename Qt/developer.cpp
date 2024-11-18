#include "developer.h"

BOOST_CLASS_EXPORT(ShpaginDeveloper)

ShpaginDeveloper::ShpaginDeveloper() : ShpaginEmployee()
{
    main_language = L"";
	is_full_stack = false;
    current_project_name = L"";
}

// std::wstring ShpaginDeveloper::getMainLanguage() const
// {
//     return main_language;
// }

// bool ShpaginDeveloper::getIsFullStack() const
// {
//     return is_full_stack;
// }

// std::wstring ShpaginDeveloper::getCurrentProjectName() const
// {
//     return current_project_name;
// }

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

void ShpaginDeveloper::setMainLanguage(std::wstring main_language)
{
    this->main_language = main_language;
}

void ShpaginDeveloper::setIsFullStack(bool is_full_stack)
{
    this->is_full_stack = is_full_stack;
}

void ShpaginDeveloper::setCurrentProjectName(std::wstring current_project_name)
{
    this->current_project_name = current_project_name;
}

namespace Language {

    QString get(const Language language)
    {
        switch(language)
        {
        case Empty:      { return "Не выбрано"; }
        case C:          { return          "C"; }
        case CPP:        { return        "C++"; }
        case C_Sharp:    { return         "C#"; }
        case Python:     { return     "Python"; }
        case Java:       { return       "Java"; }
        case JavaScript: { return "JavaScript"; }
        case Go:         { return         "Go"; }
        case TypeScript: { return "TypeScript"; }
        case PHP:        { return        "PHP"; }
        case Rust:       { return       "Rust"; }
        case Ruby:       { return       "Ruby"; }
        case Kotlin:     { return     "Kotlin"; }
        case Swift:      { return      "Swift"; }
        default:         { return           ""; }
        }
    }

    QStringList getAll()
    {
        QStringList list;
        for (int i = Language::MIN; i < Language::MAX + 1; ++i) {
            list.push_back(get(static_cast<Language>(i)));
        }
        return list;
    }

}
