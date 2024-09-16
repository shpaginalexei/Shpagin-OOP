#pragma once
#include "Employee.h"
#include <vector>


class ShpaginCompany
{
public:

	void add_employee();

	friend std::ostream& operator<< (std::ostream&, const ShpaginCompany&);

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

	std::vector<ShpaginEmployee*> employees = {};

	void clear();
	bool changed = false;
	std::string file_name = "";
	const std::string extention = ".txt";
	std::string directory = "";

};
