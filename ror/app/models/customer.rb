class Customer < ActiveRecord::Base
	belongs_to :user
	has_many :visit_plans
	has_many :visit_records
	validates :name, presence: true
	attr_accessible :name
end