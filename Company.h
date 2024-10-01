#pragma once
#include "pch.h"
#include "Employee.h"


class ShpaginCompany
{
public:
	~ShpaginCompany() {};

	void add_employee();
	void add_developer();

	friend std::ostream& operator<< (std::ostream&, const ShpaginCompany&);

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& employees;
	}

	friend std::ifstream& operator>> (std::ifstream&, ShpaginCompany&);
	friend std::ofstream& operator<< (std::ofstream&, const ShpaginCompany&);

	bool empty() const;
	bool has_saved_file() const;
	bool saved() const;
	void set_filename(const std::string&);
	void set_directory(const std::string&);
	void show_saves() const;

	void save_to_file();
	void load_from_file();
	void clear_company();

private:

	std::vector<std::shared_ptr<ShpaginEmployee>> employees = {};

	void clear();

	bool changed = false;
	std::string file_name = "";
	const std::string extention = ".txt";
	std::string directory = "";

};
