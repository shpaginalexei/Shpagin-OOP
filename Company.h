#pragma once
#include "pch.h"
#include "Employee.h"


class ShpaginCompany
{
public:
	~ShpaginCompany() {};

	void add_employee();
	void add_developer();

	friend std::wostream& operator<< (std::wostream&, const ShpaginCompany&);

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& employees;
	}

	bool empty() const;
	bool has_saved_file() const;
	bool saved() const;
	void set_filename(const std::wstring&);
	void set_directory(const std::wstring&);
	void show_saves() const;

	void save_to_file();
	void load_from_file();
	void clear_company();

private:

	std::vector<std::shared_ptr<ShpaginEmployee>> employees = {};

	void clear();

	bool changed = false;
	std::wstring file_name = L"";
	const std::wstring extention = L".txt";
	std::wstring directory = L"";

};
