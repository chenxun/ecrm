class Department < ActiveRecord::Base
	has_many :branchs, class_name: 'Department', foreign_key: 'manager_id'
	belongs_to :manager, class_name: 'Department'
	has_many :persons
end