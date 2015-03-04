class Customer < ActiveRecord::Base
	belongs_to :user
	has_many :visit_plans，:order =>'visit_plan_date  desc'
	has_many :visit_records, :order =>'visit_date  desc'
	validates :name, presence: true
	attr_accessible :name
end