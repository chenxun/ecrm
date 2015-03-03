class User < ActiveRecord::Base
	has_and_belongs_to_many :roles
	has_many :customers
	has_many :visit_records
	belongs_to :person
	has_many :soldiers, class_name: 'User', foreign_key: 'manager_id'
	belongs_to :manager, class_name: 'User'
	validates :name, uniqueness: true
	validates :name, presence: true
end