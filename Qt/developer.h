#pragma once

#include "pch.h"
#include "employee.h"

class ShpaginDeveloper : public ShpaginEmployee
{
public:
    ShpaginDeveloper();

    QStringList getColumnNames() const override;
    QStringList getData() const override;

    void setMainLanguage(std::wstring main_language);
    void setIsFullStack(bool is_full_stack);
    void setCurrentProjectName(std::wstring current_project_name);

private:
	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& boost::serialization::base_object<ShpaginEmployee>(*this);
		ar& main_language;
		ar& is_full_stack;
		ar& current_project_name;
	}

protected:
    std::wstring main_language;
	bool is_full_stack;
    std::wstring current_project_name;

};

namespace Language
{
    enum Language {
        Empty, C, CPP, C_Sharp, Python, Java, JavaScript, Go, TypeScript, PHP, Rust, Ruby, Kotlin, Swift,
        MIN = Empty, MAX = Swift,
    };
    QString get(const Language language);
    QStringList getAll();
}
