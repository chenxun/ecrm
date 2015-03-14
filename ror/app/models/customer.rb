class Customer < ActiveRecord::Base
	belongs_to :user
	has_many :visit_plans, :order =>'visit_plan_date  desc'
	has_many :visit_records, :order =>'visit_date  desc'
	validates :name, presence: true
	def self.find_by_name(name)
		name_para = '%'+name+'%'
		where("name like ? or web_site like ?", name_para, name_para)
	end
	def self.find_by_contactman(man)
		qq_para = '%'+man+'%'
		where("qq like ? or contact_man like ?", qq_para, qq_para)
	end
	def self.find_by_sales(sales)
		where('user_id=?',sales)
	end
	def self.find_by_addtime(begintime, endtime)
		where(add_time: begintime..endtime)
	end
end